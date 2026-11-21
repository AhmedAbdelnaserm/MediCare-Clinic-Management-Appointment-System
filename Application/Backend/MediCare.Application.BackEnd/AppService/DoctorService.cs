using AutoMapper;
using MediCare.Application.BackEnd.Base;
using MediCare.Application.BackEnd.Dto.DoctorDto;
using MediCare.Application.BackEnd.Localization;
using MediCare.Common.Dto;
using MediCare.Common.Enum;
using MediCare.Common.Interface;
using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IUnitOfWork;
using MediCare.IApplication.BackEnd.IAppService;
using Microsoft.Extensions.Logging;
namespace MediCare.Application.BackEnd.AppService
{
    public class DoctorService : BaseAppService, IDoctorService
    {
        public DoctorService(IMapper mapper, ILocalizationService localization,
            ILogger<DoctorService> logger, IUnitOfWork unitOfWork, ICurrentUserService currentUser) : base(mapper, localization, logger, unitOfWork, currentUser)
        {
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
        public async Task<ResponseDto<List<DoctorResponseDto>>> GetDoctors()
        {
            ResponseDto<List<DoctorResponseDto>> response = new();
            var doctors = await UnitOfWork.DoctorRepository.GetDoctors();
            if (doctors.Count == default(int))
                return response.GetErrorResponse(Localization.NoDataFound);
            var responseDto = Mapper.Map<List<DoctorResponseDto>>(doctors);
            return response.GetSuccessResponse(responseDto, Localization.GeneralSuccess);
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
        public async Task<ResponseDto<EmptyResponseDto>> CreateDoctor(CreateDoctorRequestDto doctorRequestDto)
        {
            ResponseDto<EmptyResponseDto> response = await ValidateDoctorCreateRequestData(doctorRequestDto);
            if (response.Code != ResultStatusEnum.Success)
                return response;
            var doctor = Mapper.Map<Doctor>(doctorRequestDto);
            doctor.CreatorUserId = CurrentUser.UserId
                ?? throw new InvalidOperationException("Current user is not authenticated.");
            doctor.DeleteStatusId = (int)DeleteStatusEnum.NotDeleted;
            doctor.CreationTime = DateTime.UtcNow;
            await UnitOfWork.DoctorRepository.CreateAsync(doctor);

            return await UnitOfWork.Commit() > default(int) ?
                response.GetSuccessResponse(Localization.GeneralSuccess)
                : response.GetErrorResponse(Localization.GeneralError);
        }
        public async Task<ResponseDto<EmptyResponseDto>> UpdateDoctor(int doctorId, UpdateDoctorRequestDto doctorRequestDto)
        {
            ResponseDto<EmptyResponseDto> response = await ValidateDoctorUpdateRequestData(doctorId, doctorRequestDto);
            if (response.Code != ResultStatusEnum.Success)
                return response;

            var doctor = await UnitOfWork.DoctorRepository.GetDoctorById(doctorId);
            Mapper.Map(doctorRequestDto, doctor);
            doctor.LastModifierUserId = CurrentUser.UserId
                 ?? throw new InvalidOperationException("Current user is not authenticated.");
            doctor.LastModificationTime = DateTime.UtcNow;

            UnitOfWork.DoctorRepository.Update(doctor);

            return await UnitOfWork.Commit() > default(int) ?
                 response.GetSuccessResponse(Localization.GeneralSuccess)
                 : response.GetErrorResponse(Localization.GeneralError);
        }
        public async Task<ResponseDto<EmptyResponseDto>> DeleteDoctor(int doctorId)
        {
            ResponseDto<EmptyResponseDto> response = new();
            if (doctorId <= default(int))
                return response.GetErrorResponse(Localization.InvalidData);
            var doctor = await UnitOfWork.DoctorRepository.GetDoctorById(doctorId);
            if (doctor == null)
                return response.GetErrorResponse(Localization.NoDataFound);

            doctor.LastModifierUserId = CurrentUser.UserId
                 ?? throw new InvalidOperationException("Current user is not authenticated.");
            doctor.LastModificationTime = DateTime.UtcNow;
            doctor.DeleteStatusId = (int)DeleteStatusEnum.Deleted;

            UnitOfWork.DoctorRepository.Update(doctor);

            return await UnitOfWork.Commit() > default(int) ?
                response.GetSuccessResponse(Localization.GeneralSuccess)
                : response.GetErrorResponse(Localization.GeneralError);
        }
        private async Task<ResponseDto<EmptyResponseDto>> ValidateDoctorCreateRequestData(CreateDoctorRequestDto request)
        {
            ResponseDto<EmptyResponseDto> response = new ();
            if (request == null)
                return response.GetErrorResponse(Localization.InvalidRequest);
            if (request.SpecializationId <= default(int))
                return response.GetErrorResponse(Localization.InvalidSpecialization);
            if (!Enum.IsDefined(typeof(SpecializationEnum), request.SpecializationId))
                return response.GetErrorResponse(Localization.InvalidSpecialization);
            if (!await UnitOfWork.DoctorRepository.SpecializationExists(request.SpecializationId))
                return response.GetErrorResponse(Localization.SpecializationNotFound);
            if (request.ConsultationFee < default(int))
                return response.GetErrorResponse(Localization.InvalidConsultationFee);
            if (string.IsNullOrWhiteSpace(request.EnName))
                return response.GetErrorResponse(Localization.EnNameRequired);
            if (string.IsNullOrWhiteSpace(request.EnDescription))
                return response.GetErrorResponse(Localization.EnDescriptionRequired);
            return response.GetSuccessResponse();
        }
        private async Task<ResponseDto<EmptyResponseDto>> ValidateDoctorUpdateRequestData(int doctorId, UpdateDoctorRequestDto request)
        {
            var response = new ResponseDto<EmptyResponseDto>();
            if (request == null)
                return response.GetErrorResponse(Localization.InvalidRequest);
            if (doctorId <= default(int))
                return response.GetErrorResponse(Localization.InvalidDoctorId);
            if (!await UnitOfWork.DoctorRepository.CheckIsDoctorExist(doctorId))
                return response.GetErrorResponse(Localization.DoctorNotFound);
            if (request.SpecializationId == default(int))
                return response.GetErrorResponse(Localization.InvalidSpecialization);
            if (!Enum.IsDefined(typeof(SpecializationEnum), request.SpecializationId))
                return response.GetErrorResponse(Localization.InvalidSpecialization);
            if (!await UnitOfWork.DoctorRepository.SpecializationExists(request.SpecializationId))
                return response.GetErrorResponse(Localization.SpecializationNotFound);
            if (request.ConsultationFee < default(int))
                return response.GetErrorResponse(Localization.InvalidConsultationFee);
            if (string.IsNullOrWhiteSpace(request.EnName))
                return response.GetErrorResponse(Localization.EnNameRequired);
            if (string.IsNullOrWhiteSpace(request.EnDescription))
                return response.GetErrorResponse(Localization.EnDescriptionRequired);
            return response.GetSuccessResponse();
        }
    
    }
}
