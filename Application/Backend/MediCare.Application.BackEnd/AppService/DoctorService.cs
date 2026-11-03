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
        public async Task<ResponseDto<DoctorResponseDto>> CreateDoctor(DoctorRequestDto doctorRequestDto)
        {
            ResponseDto<DoctorResponseDto> response = new();
            if (doctorRequestDto == null || string.IsNullOrWhiteSpace(doctorRequestDto.UserId) || !Enum.IsDefined(typeof(SpecializationEnum), doctorRequestDto.SpecializationId) || doctorRequestDto.ConsultationFee < 0)
                return response.GetErrorResponse(Localization.GeneralError);
            var doctor = Mapper.Map<Doctor>(doctorRequestDto);
            doctor.UserId = doctorRequestDto.UserId.Trim();
            doctor.SpecializationId = doctorRequestDto.SpecializationId;
            await UnitOfWork.DoctorRepository.CreateDoctor(doctor);
            await UnitOfWork.Commit();
            var createdDoctor = await UnitOfWork.DoctorRepository.GetDoctorById(doctor.DoctorId);
            var responseDto = Mapper.Map<DoctorResponseDto>(createdDoctor);
            return response.GetSuccessResponse(responseDto, Localization.GeneralSuccess);
        }
        public async Task<ResponseDto<DoctorResponseDto>> UpdateDoctor(DoctorRequestDto doctorRequestDto)
        {
            ResponseDto<DoctorResponseDto> response = new();
            if (doctorRequestDto == null || doctorRequestDto.DoctorId <= 0 || !Enum.IsDefined(typeof(SpecializationEnum), doctorRequestDto.SpecializationId) || doctorRequestDto.ConsultationFee < 0)
                return response.GetErrorResponse(Localization.GeneralError);
            var doctor = await UnitOfWork.DoctorRepository.GetDoctorById(doctorRequestDto.DoctorId);
            if (doctor == null)
                return response.GetErrorResponse(Localization.NoDataFound);
            Mapper.Map(doctorRequestDto, doctor);
            var updatedDoctor = await UnitOfWork.DoctorRepository.UpdateDoctor(doctor);
            await UnitOfWork.Commit();
            updatedDoctor = await UnitOfWork.DoctorRepository.GetDoctorById(doctorRequestDto.DoctorId);
            var responseDto = Mapper.Map<DoctorResponseDto>(updatedDoctor);
            return response.GetSuccessResponse(responseDto, Localization.GeneralSuccess);
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
