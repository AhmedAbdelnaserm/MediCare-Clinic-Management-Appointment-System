using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using global::MediCare.Application.BackEnd.Dto.Dto.Paitient;
using global::MediCare.Core.Entity.Entity;
using global::MediCare.Core.IRepository.IRepository;
using global::MediCare.IApplication.BackEnd.IAppService;
using MediCare.Common.Dto;
using MediCare.Common.Enum;
using Microsoft.AspNetCore.Identity;

namespace MediCare.Application.BackEnd.AppService
{
    public class PatientAppService : IPatientAppService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public PatientAppService(IPatientRepository patientRepository, UserManager<ApplicationUser> userManager)
        {
            _patientRepository = patientRepository;
            _userManager = userManager;
        }

        public async Task<ResponseDto<IEnumerable<PatientDto>>> GetAllAsync()
        {
            var response = new ResponseDto<IEnumerable<PatientDto>>();

            var patients = await _patientRepository.GetAllWithUserAsync();
            var data = patients.Select(MapToDto);

            return response.GetSuccessResponse(data, "Patients retrieved successfully.");
        }

        public async Task<ResponseDto<PatientDto>> GetByIdAsync(int patientId)
        {
            var response = new ResponseDto<PatientDto>();

            if (patientId <= 0)
                return response.GetErrorResponse("Invalid patient id.");

            var patient = await _patientRepository.GetByIdWithUserAsync(patientId);
            if (patient == null)
                return response.GetErrorResponse($"Patient with id {patientId} was not found.");

            return response.GetSuccessResponse(MapToDto(patient), "Patient retrieved successfully.");
        }

        public async Task<ResponseDto<PatientDto>> GetMyProfileAsync(string currentUserId)
        {
            var response = new ResponseDto<PatientDto>();

            if (string.IsNullOrWhiteSpace(currentUserId))
                return response.GetErrorResponse("User is not authenticated.");

            var patient = await _patientRepository.GetByUserIdAsync(currentUserId);
            if (patient == null)
                return response.GetErrorResponse("No patient profile is linked to the current user.");

            return response.GetSuccessResponse(MapToDto(patient), "Patient profile retrieved successfully.");
        }

        public async Task<ResponseDto<PatientDto>> CreateAsync(CreatePatientDto dto, string currentUserId)
        {
            var response = new ResponseDto<PatientDto>();

            if (dto == null)
                return response.GetErrorResponse("Invalid request data.");

            // Resolve the ApplicationUser this profile belongs to:
            // admins/doctors may target another user; patients only themselves.
            var targetUserId = string.IsNullOrWhiteSpace(dto.UserId) ? currentUserId : dto.UserId;
            if (string.IsNullOrWhiteSpace(targetUserId))
                return response.GetErrorResponse("User ID is required to link the patient profile.");

            var user = await _userManager.FindByIdAsync(targetUserId);
            if (user == null)
                return response.GetErrorResponse($"ApplicationUser '{targetUserId}' was not found.");

            // A user can have only one patient profile (1:1 relationship)
            var existing = await _patientRepository.GetByUserIdAsync(targetUserId);
            if (existing != null)
                return response.GetErrorResponse("This user already has a patient profile.");

            if (dto.DateOfBirth > DateOnly.FromDateTime(DateTime.UtcNow))
                return response.GetErrorResponse("Date of birth cannot be in the future.");

            var entity = new Patient
            {
                UserId = user.Id,
                DateOfBirth = dto.DateOfBirth,
                GenderId = dto.GenderId.ToString(),
                MedicalHistory = dto.MedicalHistory?.Trim(),
                Allergies = dto.Allergies?.Trim(),
                CreationTime = DateTime.UtcNow
            };

            await _patientRepository.AddAsync(entity);

            entity.User = user;
            return response.GetSuccessResponse(MapToDto(entity), "Patient created successfully.");
        }

        public async Task<ResponseDto<PatientDto>> UpdateAsync(UpdatePatientDto dto, string currentUserId)
        {
            var response = new ResponseDto<PatientDto>();

            if (dto == null || dto.PatientId <= 0)
                return response.GetErrorResponse("Invalid request data.");

            var patient = await _patientRepository.GetByIdAsync(dto.PatientId);
            if (patient == null)
                return response.GetErrorResponse($"Patient with id {dto.PatientId} was not found.");

            // Authorization rule: a Patient may only update their own profile.
            var currentUser = await _userManager.FindByIdAsync(currentUserId);
            var isPatientRole = currentUser != null && await _userManager.IsInRoleAsync(currentUser, nameof(UserRolesEnum.Patient));
            if (isPatientRole && patient.UserId != currentUserId)
                return response.GetErrorResponse("You are not allowed to update this patient profile.");

            if (dto.DateOfBirth > DateOnly.FromDateTime(DateTime.UtcNow))
                return response.GetErrorResponse("Date of birth cannot be in the future.");

            patient.DateOfBirth = dto.DateOfBirth;
            patient.GenderId = dto.GenderId.ToString();
            patient.MedicalHistory = dto.MedicalHistory?.Trim();
            patient.Allergies = dto.Allergies?.Trim();
            patient.LastModificationTime = DateTime.UtcNow;
            patient.LastModifierUserId = currentUserId;

            await _patientRepository.UpdateAsync(patient);

            var updated = await _patientRepository.GetByIdWithUserAsync(patient.PatientId);
            return response.GetSuccessResponse(MapToDto(updated ?? patient), "Patient updated successfully.");
        }

        public async Task<ResponseDto<bool>> DeleteAsync(int patientId, string currentUserId)
        {
            var response = new ResponseDto<bool>();

            if (patientId <= 0)
                return response.GetErrorResponse("Invalid patient id.");

            var patient = await _patientRepository.GetByIdAsync(patientId);
            if (patient == null)
                return response.GetErrorResponse($"Patient with id {patientId} was not found.");

            var currentUser = await _userManager.FindByIdAsync(currentUserId);
            var isPatientRole = currentUser != null && await _userManager.IsInRoleAsync(currentUser, nameof(UserRolesEnum.Patient));
            if (isPatientRole && patient.UserId != currentUserId)
                return response.GetErrorResponse("You are not allowed to delete this patient profile.");

            await _patientRepository.DeleteAsync(patient);
            return response.GetSuccessResponse(true, "Patient deleted successfully.");
        }

        private static PatientDto MapToDto(Patient entity)
        {
            return new PatientDto
            {
                PatientId = entity.PatientId,
                UserId = entity.UserId,
                UserName = entity.User?.UserName,
                Email = entity.User?.Email,
                FullName = entity.User?.FullName,
                PhoneNumber = entity.User?.PhoneNumber,
                DateOfBirth = entity.DateOfBirth,
                Gender = ParseGender(entity.GenderId),
                MedicalHistory = entity.MedicalHistory,
                Allergies = entity.Allergies
            };
        }

        private static string? ParseGender(string? genderId)
        {
            if (int.TryParse(genderId, out var id) && Enum.IsDefined(typeof(GenderEnum), id))
                return ((GenderEnum)id).ToString();
            return genderId;
        }
    }
}
