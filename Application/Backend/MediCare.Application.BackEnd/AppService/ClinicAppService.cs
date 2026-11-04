
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
        public ClinicAppService(
            IMapper mapper,
            ILocalizationService localization,
            ILogger<ClinicAppService> logger,
            IUnitOfWork unitOfWork)
            : base(mapper, localization, logger, unitOfWork)
        {
        }

        public async Task<ResponseDto<TextValueBindingResponseDto>> GetClinic(int clinicId)
        {
            ResponseDto<TextValueBindingResponseDto> response = new();

            if (clinicId <= 0)
                return response.GetErrorResponse(Localization.InvalidData);

            var clinic = await UnitOfWork.ClinicRepository.GetClinic(clinicId);

            if (clinic == null)
                return response.GetErrorResponse(Localization.NoDataFound);

            var responseDto = Mapper.Map<TextValueBindingResponseDto>(clinic);

            return response.GetSuccessResponse(responseDto, Localization.GeneralSuccess);
        }

        public async Task<ResponseDto<List<TextValueBindingResponseDto>>> GetClinics()
        {
            ResponseDto<List<TextValueBindingResponseDto>> response = new();

            var clinics = await UnitOfWork.ClinicRepository.GetClinics();

            if (clinics.Count == 0)
                return response.GetErrorResponse(Localization.NoDataFound);

            var responseDto = Mapper.Map<List<TextValueBindingResponseDto>>(clinics);

            return response.GetSuccessResponse(responseDto, Localization.GeneralSuccess);
        }

        public async Task<ResponseDto<List<TextValueBindingResponseDto>>> GetClinicsByAreaId(int areaId)
        {
            ResponseDto<List<TextValueBindingResponseDto>> response = new();

            if (areaId <= 0)
                return response.GetErrorResponse(Localization.InvalidData);

            var clinics = await UnitOfWork.ClinicRepository.GetClinicsByAreaId(areaId);

            if (clinics.Count == 0)
                return response.GetErrorResponse(Localization.NoDataFound);

            var responseDto = Mapper.Map<List<TextValueBindingResponseDto>>(clinics);

            return response.GetSuccessResponse(responseDto, Localization.GeneralSuccess);
        }

        public async Task<ResponseDto<ClinicDto>> CreateClinic(SaveClinicDto clinicDto)
        {
            ResponseDto<ClinicDto> response = new();

            if (clinicDto == null || clinicDto.AreaId <= 0)
                return response.GetErrorResponse(Localization.InvalidData);

            var areaExists = await UnitOfWork.AreaRepository.CheckIsAreaExist(clinicDto.AreaId);

            if (!areaExists)
                return response.GetErrorResponse(Localization.InvalidData);

            var clinic = Mapper.Map<Clinic>(clinicDto);

            clinic.DeleteStatusId = (int)DeleteStatusEnum.NotDeleted;
            clinic.CreationTime = DateTime.UtcNow;

            await UnitOfWork.ClinicRepository.CreateClinic(clinic);
            await UnitOfWork.Commit();

            var responseDto = Mapper.Map<ClinicDto>(clinic);

            return response.GetSuccessResponse(responseDto, Localization.GeneralSuccess);
        }

        public async Task<ResponseDto<ClinicDto>> UpdateClinic(int clinicId, SaveClinicDto clinicDto)
        {
            ResponseDto<ClinicDto> response = new();

            if (clinicId <= 0 || clinicDto == null || clinicDto.AreaId <= 0)
                return response.GetErrorResponse(Localization.InvalidData);

            var clinic = await UnitOfWork.ClinicRepository.GetClinic(clinicId);

            if (clinic == null)
                return response.GetErrorResponse(Localization.NoDataFound);

            var areaExists = await UnitOfWork.AreaRepository.CheckIsAreaExist(clinicDto.AreaId);

            if (!areaExists)
                return response.GetErrorResponse(Localization.InvalidData);

            Mapper.Map(clinicDto, clinic);

            clinic.LastModificationTime = DateTime.UtcNow;

            UnitOfWork.ClinicRepository.UpdateClinic(clinic);

            await UnitOfWork.Commit();

            var responseDto = Mapper.Map<ClinicDto>(clinic);

            return response.GetSuccessResponse(responseDto, Localization.GeneralSuccess);
        }

        public async Task<ResponseDto<bool>> DeleteClinic(int clinicId)
        {
            ResponseDto<bool> response = new();

            if (clinicId <= 0)
                return response.GetErrorResponse(Localization.InvalidData);

            var clinic = await UnitOfWork.ClinicRepository.GetClinic(clinicId);

            if (clinic == null)
                return response.GetErrorResponse(Localization.NoDataFound);

            clinic.DeleteStatusId = (int)DeleteStatusEnum.Deleted;
            clinic.LastModificationTime = DateTime.UtcNow;

            UnitOfWork.ClinicRepository.UpdateClinic(clinic);

            await UnitOfWork.Commit();

            return response.GetSuccessResponse(true, Localization.GeneralSuccess);
        }


        public async Task<ResponseDto<ClinicDto>> GetClinicDetails(int clinicId)
        {
            ResponseDto<ClinicDto> response = new();

            if (clinicId <= 0)
                return response.GetErrorResponse(Localization.InvalidData);

            var clinic = await UnitOfWork.ClinicRepository.GetClinic(clinicId);

            if (clinic == null)
                return response.GetErrorResponse(Localization.NoDataFound);

            var responseDto = Mapper.Map<ClinicDto>(clinic);

            return response.GetSuccessResponse(responseDto, Localization.GeneralSuccess);
        }

    }
}
