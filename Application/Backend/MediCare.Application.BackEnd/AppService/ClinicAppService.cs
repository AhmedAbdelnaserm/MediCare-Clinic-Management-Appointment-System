
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

        private async Task<ResponseDto<EmptyResponseDto>> ValidateClinicRequestData(
     string enName, string address, int areaId)
        {
            ResponseDto<EmptyResponseDto> response = new();

            if (string.IsNullOrWhiteSpace(enName))
                return response.GetErrorResponse(Localization.ClinicNameRequired);

            if (string.IsNullOrWhiteSpace(address))
                return response.GetErrorResponse(Localization.ClinicAddressRequired);

            if (areaId <= default(int))
                return response.GetErrorResponse(Localization.ClinicAreaRequired);

            var areaExists = await UnitOfWork.AreaRepository.CheckIsAreaExist(areaId);

            if (!areaExists)
                return response.GetErrorResponse(Localization.ClinicAreaNotFound);

            return response.GetSuccessResponse(Localization.GeneralSuccess);
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
            ResponseDto<EmptyResponseDto> response = new();

            if (clinicDto == null)
                return response.GetErrorResponse(Localization.InvalidRequest);

            var validationResponse = await ValidateClinicRequestData(
                clinicDto.EnName, clinicDto.Address, clinicDto.AreaId);

            if (validationResponse.Code != ResultStatusEnum.Success)
                return response.GetErrorResponse(validationResponse.Message);

            var clinic = Mapper.Map<Clinic>(clinicDto);

            clinic.DeleteStatusId = (int)DeleteStatusEnum.NotDeleted;
            clinic.CreationTime = DateTime.UtcNow;

            await UnitOfWork.ClinicRepository.CreateClinic(clinic);
            await UnitOfWork.Commit();

            return response.GetSuccessResponse(Localization.GeneralSuccess);
        }

        public async Task<ResponseDto<EmptyResponseDto>> UpdateClinic(int clinicId, UpdateClinicRequestDto clinicDto)
        {
            ResponseDto<EmptyResponseDto> response = new();

            if (clinicId <= default(int))
                return response.GetErrorResponse(Localization.InvalidData);

            if (clinicDto == null)
                return response.GetErrorResponse(Localization.InvalidRequest);

            var validationResponse = await ValidateClinicRequestData(
                clinicDto.EnName, clinicDto.Address, clinicDto.AreaId);

            if (validationResponse.Code != ResultStatusEnum.Success)
                return response.GetErrorResponse(validationResponse.Message);

            var clinic = await UnitOfWork.ClinicRepository.GetClinic(clinicId);

            if (clinic == null)
                return response.GetErrorResponse(Localization.NoDataFound);

            Mapper.Map(clinicDto, clinic);

            clinic.LastModificationTime = DateTime.UtcNow;

            await UnitOfWork.ClinicRepository.UpdateClinic(clinic);
            await UnitOfWork.Commit();

            return response.GetSuccessResponse(Localization.GeneralSuccess);
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

            await UnitOfWork.ClinicRepository.DeleteClinic(clinic);
            await UnitOfWork.Commit();

            return response.GetSuccessResponse(Localization.GeneralSuccess);
        }
    }
}
