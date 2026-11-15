
using AutoMapper;
using MediCare.Application.BackEnd.Base;
using MediCare.Application.BackEnd.Localization;
using MediCare.Common.Dto;
using MediCare.Common.Enum;
using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IUnitOfWork;
using MediCare.IApplication.BackEnd.IAppService;
using Microsoft.Extensions.Logging;

namespace MediCare.Application.BackEnd.AppService
{
    public class ClinicAppService : BaseAppService, IClinicAppService
    {
        public ClinicAppService(IMapper mapper, ILocalizationService localization, ILogger<ClinicAppService> logger, IUnitOfWork unitOfWork)
            : base(mapper, localization, logger, unitOfWork)
        {
        }

        public async Task<ResponseDto<ClinicDto>> GetClinic(int clinicId)
        {
            ResponseDto<ClinicDto> response = new();

            if (clinicId <= default(int))
                return response.GetErrorResponse(Localization.InvalidData);

            var clinic = await UnitOfWork.ClinicRepository.GetClinic(clinicId);

            if (clinic == null)
                return response.GetErrorResponse(Localization.NoDataFound);

            var responseDto = Mapper.Map<ClinicDto>(clinic);

            return response.GetSuccessResponse(responseDto, Localization.GeneralSuccess);
        }

        public async Task<ResponseDto<List<TextValueBindingResponseDto>>> GetClinics()
        {
            ResponseDto<List<TextValueBindingResponseDto>> response = new();

            var clinics = await UnitOfWork.ClinicRepository.GetClinics();

            if (clinics.Count == default(int))
                return response.GetErrorResponse(Localization.NoDataFound);

            var responseDto = Mapper.Map<List<TextValueBindingResponseDto>>(clinics);

            return response.GetSuccessResponse(responseDto, Localization.GeneralSuccess);
        }

        public async Task<ResponseDto<List<TextValueBindingResponseDto>>> GetClinicsByAreaId(int areaId)
        {
            ResponseDto<List<TextValueBindingResponseDto>> response = new();

            if (areaId <= default(int))
                return response.GetErrorResponse(Localization.InvalidData);

            var clinics = await UnitOfWork.ClinicRepository.GetClinicsByAreaId(areaId);

            if (clinics.Count == default(int))
                return response.GetErrorResponse(Localization.NoDataFound);

            var responseDto = Mapper.Map<List<TextValueBindingResponseDto>>(clinics);

            return response.GetSuccessResponse(responseDto, Localization.GeneralSuccess);
        }

        public async Task<ResponseDto<EmptyResponseDto>> CreateClinic(CreateClinicRequestDto clinicDto)
        {
            ResponseDto<EmptyResponseDto> response = await ValidateCreateClinicRequestData(clinicDto);
            if (response.Code == ResultStatusEnum.Error)
                return response.GetErrorResponse(response.Message);

            var clinic = Mapper.Map<Clinic>(clinicDto);

            clinic.DeleteStatusId = (int)DeleteStatusEnum.NotDeleted;
            clinic.CreationTime = DateTime.UtcNow;

            await UnitOfWork.ClinicRepository.CreateAsync(clinic);

            return await UnitOfWork.Commit() > default(int) ?
                response.GetSuccessResponse(Localization.GeneralSuccess)
                : response.GetErrorResponse(Localization.GeneralError);
        }

        public async Task<ResponseDto<EmptyResponseDto>> UpdateClinic(int clinicId, UpdateClinicRequestDto clinicDto)
        {
            ResponseDto<EmptyResponseDto> response = await ValidateUpdateClinicRequestData(clinicId, clinicDto);
            if (response.Code != ResultStatusEnum.Success)
                return response.GetErrorResponse(response.Message);

            var clinic = await UnitOfWork.ClinicRepository.GetClinic(clinicId);
            Mapper.Map(clinicDto, clinic);

            clinic.LastModificationTime = DateTime.UtcNow;

            UnitOfWork.ClinicRepository.Update(clinic);

            return await UnitOfWork.Commit() > default(int) ?
                response.GetSuccessResponse(Localization.GeneralSuccess)
                : response.GetErrorResponse(Localization.GeneralError);
        }

        public async Task<ResponseDto<EmptyResponseDto>> DeleteClinic(int clinicId)
        {
            ResponseDto<EmptyResponseDto> response = new();

            if (clinicId <= default(int))
                return response.GetErrorResponse(Localization.InvalidData);

            var clinic = await UnitOfWork.ClinicRepository.GetClinic(clinicId);

            if (clinic == null)
                return response.GetErrorResponse(Localization.NoDataFound);

            clinic.LastModificationTime = DateTime.UtcNow;
            clinic.DeleteStatusId = (int)DeleteStatusEnum.Deleted;
            UnitOfWork.ClinicRepository.Update(clinic);

            return await UnitOfWork.Commit() > default(int) ?
                response.GetSuccessResponse(Localization.GeneralSuccess)
                : response.GetErrorResponse(Localization.GeneralError);
        }

        private async Task<ResponseDto<EmptyResponseDto>> ValidateCreateClinicRequestData(CreateClinicRequestDto request)
        {
            ResponseDto<EmptyResponseDto> response = new();

            if (request == null)
                return response.GetErrorResponse(Localization.InvalidRequest);

            if (string.IsNullOrWhiteSpace(request.EnName))
                return response.GetErrorResponse(Localization.ClinicNameRequired);

            if (string.IsNullOrWhiteSpace(request.Address))
                return response.GetErrorResponse(Localization.ClinicAddressRequired);

            if (request.AreaId <= default(int))
                return response.GetErrorResponse(Localization.AreaRequired);

            var areaExists = await UnitOfWork.AreaRepository.CheckIsAreaExist(request.AreaId);

            if (!areaExists)
                return response.GetErrorResponse(Localization.AreaNotFound);

            return response.GetSuccessResponse(Localization.GeneralSuccess);
        }
        private async Task<ResponseDto<EmptyResponseDto>> ValidateUpdateClinicRequestData(int clinicId, UpdateClinicRequestDto request)
        {
            ResponseDto<EmptyResponseDto> response = new();

            if (clinicId <= default(int))
                return response.GetErrorResponse(Localization.InvalidData);

            if (request == null)
                return response.GetErrorResponse(Localization.InvalidRequest);

            if (string.IsNullOrWhiteSpace(request.EnName))
                return response.GetErrorResponse(Localization.ClinicNameRequired);

            if (string.IsNullOrWhiteSpace(request.Address))
                return response.GetErrorResponse(Localization.ClinicAddressRequired);

            if (request.AreaId <= default(int))
                return response.GetErrorResponse(Localization.AreaRequired);

            var areaExists = await UnitOfWork.AreaRepository.CheckIsAreaExist(request.AreaId);
            if (!areaExists)
                return response.GetErrorResponse(Localization.AreaNotFound);

            var clinicExists = await UnitOfWork.ClinicRepository.GetClinic(clinicId);
            if (clinicExists == null)
                return response.GetErrorResponse(Localization.ClinicNotFound);

            return response.GetSuccessResponse(Localization.GeneralSuccess);
        }
    }
}
