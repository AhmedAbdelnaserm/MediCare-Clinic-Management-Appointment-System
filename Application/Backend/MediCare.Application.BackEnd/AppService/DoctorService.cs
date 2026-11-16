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
        public async Task<ResponseDto<EmptyResponseDto>> CreateDoctor(CreateDoctorRequestDto doctorRequestDto)
        {
            var response = await ValidateDoctorCreateRequestData(doctorRequestDto);
            if (response.Code != ResultStatusEnum.Success)
                return response;
            var doctor = Mapper.Map<Doctor>(doctorRequestDto);
            doctor.ArDescription = string.Empty;
            doctor.ArName = string.Empty;
            await UnitOfWork.DoctorRepository.CreateDoctor(doctor);
            await UnitOfWork.Commit();
            return response.GetSuccessResponse(Localization.GeneralSuccess);
        }
        public async Task<ResponseDto<EmptyResponseDto>> UpdateDoctor(int doctorId, UpdateDoctorRequestDto? doctorRequestDto)
        {
            var response = await ValidateDoctorUpdateRequestData(doctorId, doctorRequestDto);
            if (response.Code != ResultStatusEnum.Success)
                return response;
            var request = doctorRequestDto!;
            var doctor = await UnitOfWork.DoctorRepository.GetDoctorById(doctorId);
            Mapper.Map(request, doctor);
            await UnitOfWork.DoctorRepository.UpdateDoctor(doctor);
            await UnitOfWork.Commit();
            return response.GetSuccessResponse(Localization.GeneralSuccess);
        }

        private async Task<ResponseDto<EmptyResponseDto>> ValidateDoctorCreateRequestData(CreateDoctorRequestDto request)
        {
            var response = new ResponseDto<EmptyResponseDto>();
            if (request == null)
                return response.GetErrorResponse(Localization.InvalidRequest);
            if (request.SpecializationId <= 0)
                return response.GetErrorResponse(Localization.InvalidSpecialization);
            if (!Enum.IsDefined(typeof(SpecializationEnum), request.SpecializationId))
                return response.GetErrorResponse(Localization.InvalidSpecialization);
            if (!await UnitOfWork.DoctorRepository.SpecializationExists(request.SpecializationId))
                return response.GetErrorResponse(Localization.SpecializationNotFound);
            if (request.ConsultationFee < 0)
                return response.GetErrorResponse(Localization.InvalidConsultationFee);
            if (string.IsNullOrWhiteSpace(request.EnName))
                return response.GetErrorResponse(Localization.EnNameRequired);
            if (string.IsNullOrWhiteSpace(request.EnDescription))
                return response.GetErrorResponse(Localization.EnDescriptionRequired);
            return response.GetSuccessResponse();
        }
        private async Task<ResponseDto<EmptyResponseDto>> ValidateDoctorUpdateRequestData(int doctorId, UpdateDoctorRequestDto? request)
        {
            var response = new ResponseDto<EmptyResponseDto>();
            if (request == null)
                return response.GetErrorResponse(Localization.InvalidRequest);
            if (doctorId <= 0)
                return response.GetErrorResponse(Localization.InvalidDoctorId);
            if (!await UnitOfWork.DoctorRepository.CheckIsDoctorExist(doctorId))
                return response.GetErrorResponse(Localization.DoctorNotFound);
            if (request.SpecializationId == default(int))
                return response.GetErrorResponse(Localization.InvalidSpecialization);
            if (!Enum.IsDefined(typeof(SpecializationEnum), request.SpecializationId))
                return response.GetErrorResponse(Localization.InvalidSpecialization);
            if (!await UnitOfWork.DoctorRepository.SpecializationExists(request.SpecializationId))
                return response.GetErrorResponse(Localization.SpecializationNotFound);
            if (request.ConsultationFee < 0)
                return response.GetErrorResponse(Localization.InvalidConsultationFee);
            if (string.IsNullOrWhiteSpace(request.EnName))
                return response.GetErrorResponse(Localization.EnNameRequired);
            if (string.IsNullOrWhiteSpace(request.EnDescription))
                return response.GetErrorResponse(Localization.EnDescriptionRequired);
            return response.GetSuccessResponse();
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
        public async Task<ResponseDto<EmptyResponseDto>> DeleteDoctor(int doctorId)
        {
            ResponseDto<EmptyResponseDto> response = new();
            var isDeleted = await UnitOfWork.DoctorRepository.DeleteDoctor(doctorId);
            if (!isDeleted)
                return response.GetErrorResponse(Localization.GeneralError);
            await UnitOfWork.Commit();
            return response.GetSuccessResponse(Localization.GeneralSuccess);
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
    
    
  
    }
}
