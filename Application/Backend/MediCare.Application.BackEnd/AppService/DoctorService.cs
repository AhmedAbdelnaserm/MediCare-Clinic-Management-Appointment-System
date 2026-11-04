using AutoMapper;
using MediCare.Application.BackEnd.Base;
using MediCare.Application.BackEnd.Localization;
using MediCare.Common.Dto;
using MediCare.Common.Enum;
using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IUnitOfWork;
using MediCare.IApplication.BackEnd.IAppService;
using Microsoft.Extensions.Logging;
using MediCare.Application.BackEnd.Dto.Dto;
namespace MediCare.Application.BackEnd.AppService
{
    public class DoctorService : BaseAppService, IDoctorService
    {
        public DoctorService(IMapper mapper, ILocalizationService localization, ILogger<DoctorService> logger, IUnitOfWork unitOfWork) : base(mapper, localization, logger, unitOfWork)
        {
        }
        public async Task<ResponseDto<EmptyResponseDto>> CreateDoctor(DoctorRequestDto doctorRequestDto)
        {
            var response = await ValidateDoctorCreateRequestData(doctorRequestDto);
            if (response.Code != ResultStatusEnum.Success)
                return response;
            var doctor = Mapper.Map<Doctor>(doctorRequestDto);
            doctor.UserId = doctorRequestDto.UserId.Trim();
            doctor.SpecializationId = doctorRequestDto.SpecializationId;
            await UnitOfWork.DoctorRepository.CreateDoctor(doctor);
            await UnitOfWork.Commit();
            return response.GetSuccessResponse(new EmptyResponseDto(), Localization.GeneralSuccess);
        }
        public async Task<ResponseDto<EmptyResponseDto>> UpdateDoctor(DoctorRequestDto doctorRequestDto)
        {
            var response = await ValidateDoctorUpdateRequestData(doctorRequestDto);
            if (response.Code != ResultStatusEnum.Success)
                return response;
            var doctor = await UnitOfWork.DoctorRepository.GetDoctorById(doctorRequestDto.DoctorId);
            Mapper.Map(doctorRequestDto, doctor);
            await UnitOfWork.DoctorRepository.UpdateDoctor(doctor);
            await UnitOfWork.Commit();
            return response.GetSuccessResponse(new EmptyResponseDto(), Localization.GeneralSuccess);
        }

        private async Task<ResponseDto<EmptyResponseDto>> ValidateDoctorCreateRequestData(DoctorRequestDto request)
        {
            var response = new ResponseDto<EmptyResponseDto>();
            if (request == null)
                return response.GetErrorResponse("Doctor request is required.");
            if (string.IsNullOrWhiteSpace(request.UserId))
                return response.GetErrorResponse("UserId is required.");
            var userId = request.UserId.Trim();
            if (!await UnitOfWork.DoctorRepository.UserExists(userId))
                return response.GetErrorResponse("UserId must match an existing registered user.");
            if (await UnitOfWork.DoctorRepository.DoctorExistsForUser(userId))
                return response.GetErrorResponse("This user is already linked to a doctor.");
            if (!Enum.IsDefined(typeof(SpecializationEnum), request.SpecializationId))
                return response.GetErrorResponse("SpecializationId must be a valid specialization enum value.");
            if (!await UnitOfWork.DoctorRepository.SpecializationExists(request.SpecializationId))
                return response.GetErrorResponse("The selected specialization is missing from the database. Apply the specialization migration.");
            if (request.ConsultationFee < 0)
                return response.GetErrorResponse("ConsultationFee cannot be negative.");
            if (string.IsNullOrWhiteSpace(request.EnName))
                return response.GetErrorResponse("EnName is required.");
            if (string.IsNullOrWhiteSpace(request.ArName))
                return response.GetErrorResponse("ArName is required.");
            if (string.IsNullOrWhiteSpace(request.EnDescription))
                return response.GetErrorResponse("EnDescription is required.");
            if (string.IsNullOrWhiteSpace(request.ArDescription))
                return response.GetErrorResponse("ArDescription is required.");

            return response.GetSuccessResponse(new EmptyResponseDto());
        }
        private async Task<ResponseDto<EmptyResponseDto>> ValidateDoctorUpdateRequestData(DoctorRequestDto request)
        {
            var response = new ResponseDto<EmptyResponseDto>();
            if (request == null)
                return response.GetErrorResponse("Doctor request is required.");
            if (request.DoctorId <= 0)
                return response.GetErrorResponse("DoctorId must be greater than zero.");
            if (!await UnitOfWork.DoctorRepository.CheckIsDoctorExist(request.DoctorId))
                return response.GetErrorResponse("Doctor was not found.");
            if (!Enum.IsDefined(typeof(SpecializationEnum), request.SpecializationId))
                return response.GetErrorResponse("SpecializationId must be a valid specialization enum value.");
            if (!await UnitOfWork.DoctorRepository.SpecializationExists(request.SpecializationId))
                return response.GetErrorResponse("The selected specialization is missing from the database. Apply the specialization migration.");
            if (request.ConsultationFee < 0)
                return response.GetErrorResponse("ConsultationFee cannot be negative.");
            if (string.IsNullOrWhiteSpace(request.EnName))
                return response.GetErrorResponse("EnName is required.");
            if (string.IsNullOrWhiteSpace(request.ArName))
                return response.GetErrorResponse("ArName is required.");
            if (string.IsNullOrWhiteSpace(request.EnDescription))
                return response.GetErrorResponse("EnDescription is required.");
            if (string.IsNullOrWhiteSpace(request.ArDescription))
                return response.GetErrorResponse("ArDescription is required.");
            return response.GetSuccessResponse(new EmptyResponseDto());
        }
        public async Task<ResponseDto<List<DoctorResponseDto>>> GetDoctors()
        {
            ResponseDto<List<DoctorResponseDto>> response = new();
            var doctors = await UnitOfWork.DoctorRepository.GetDoctors();
            if (doctors.Count == default(int))
                return response.GetErrorResponse(Localization.NoDataFound);
            var responseDto = Mapper.Map<List<DoctorResponseDto>>(doctors);
            return response.GetSuccessResponse(responseDto, Localization.GeneralSuccess);
        }
        public async Task<ResponseDto<DoctorResponseDto>> GetDoctorById(int doctorId)
        {
            ResponseDto<DoctorResponseDto> response = new();
            var doctor = await UnitOfWork.DoctorRepository.GetDoctorById(doctorId);
            if (doctor == null)
                return response.GetErrorResponse(Localization.NoDataFound);
            var responseDto = Mapper.Map<DoctorResponseDto>(doctor);
            return response.GetSuccessResponse(responseDto, Localization.GeneralSuccess);
        }
        public async Task<ResponseDto<bool>> DeleteDoctor(int doctorId)
        {
            ResponseDto<bool> response = new();
            var isDeleted = await UnitOfWork.DoctorRepository.DeleteDoctor(doctorId);
            if (!isDeleted)
                return response.GetErrorResponse(Localization.GeneralError);
            await UnitOfWork.Commit();
            return response.GetSuccessResponse(isDeleted, Localization.GeneralSuccess);
        }
        public async Task<ResponseDto<List<DoctorResponseDto>>> GetDoctorsBySpecializationId(int specializationId)
        {
            ResponseDto<List<DoctorResponseDto>> response = new();
            var doctors = await UnitOfWork.DoctorRepository.GetDoctorsBySpecializationId(specializationId);
            if (doctors.Count == default(int))
                return response.GetErrorResponse(Localization.NoDataFound);
            var responseDto = Mapper.Map<List<DoctorResponseDto>>(doctors);
            return response.GetSuccessResponse(responseDto, Localization.GeneralSuccess);
        }
        public async Task<ResponseDto<List<DoctorResponseDto>>> GetDoctorsByClinicId(int clinicId)
        {
            ResponseDto<List<DoctorResponseDto>> response = new();
            var doctors = await UnitOfWork.DoctorRepository.GetDoctorsByClinicId(clinicId);
            if (doctors.Count == default(int))
                return response.GetErrorResponse(Localization.NoDataFound);
            var responseDto = Mapper.Map<List<DoctorResponseDto>>(doctors);
            return response.GetSuccessResponse(responseDto, Localization.GeneralSuccess);
        }
        public async Task<ResponseDto<List<DoctorResponseDto>>> GetDoctorsByClinicIdAndSpecializationId(int clinicId, int specializationId)
        {
            ResponseDto<List<DoctorResponseDto>> response = new();
            var doctors = await UnitOfWork.DoctorRepository.GetDoctorsByClinicIdAndSpecializationId(clinicId, specializationId);
            if (doctors.Count == default(int))
                return response.GetErrorResponse(Localization.NoDataFound);
            var responseDto = Mapper.Map<List<DoctorResponseDto>>(doctors);
            return response.GetSuccessResponse(responseDto, Localization.GeneralSuccess);
        }
        public async Task<ResponseDto<List<AppointmentResponseDto>>> GetAppointmentsByDoctorId(int doctorId)
        {
            ResponseDto<List<AppointmentResponseDto>> response = new();
            var appointments = await UnitOfWork.DoctorRepository.GetAppointmentsByDoctorId(doctorId);
            if (appointments.Count == default(int))
                return response.GetErrorResponse(Localization.NoDataFound);
            var responseDto = Mapper.Map<List<AppointmentResponseDto>>(appointments);
            return response.GetSuccessResponse(responseDto, Localization.GeneralSuccess);
        }
        public async Task<ResponseDto<List<SlotResponseDto>>> GetSlotsByDoctorId(int doctorId)
        {
            ResponseDto<List<SlotResponseDto>> response = new();
            var slots = await UnitOfWork.DoctorRepository.GetSlotsByDoctorId(doctorId);
            if (slots.Count == default(int))
                return response.GetErrorResponse(Localization.NoDataFound);
            var responseDto = Mapper.Map<List<SlotResponseDto>>(slots);
            return response.GetSuccessResponse(responseDto, Localization.GeneralSuccess);
        }
  
        

    }
}
