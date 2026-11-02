using AutoMapper;
using MediCare.Application.BackEnd.Base;
using MediCare.Application.BackEnd.Localization;
using MediCare.Common.Dto;
using MediCare.Core.IRepository.IUnitOfWork;
using MediCare.IApplication.BackEnd.IAppService;
using Microsoft.Extensions.Logging;

namespace MediCare.Application.BackEnd.AppService
{
    public class AreaAppService : BaseAppService, IAreaAppService
    {
        public AreaAppService(IMapper mapper, ILocalizationService localization, ILogger<AreaAppService> logger, IUnitOfWork unitOfWork) : base(mapper, localization, logger, unitOfWork)
        {
        }

        public async Task<ResponseDto<TextValueBindingResponseDto>> GetArea(int areaId)
        {
            ResponseDto<TextValueBindingResponseDto> response = new();
            if (areaId <= 0)
                return response.GetErrorResponse(Localization.InvalidData);
            var area = await UnitOfWork.AreaRepository.GetArea(areaId);
            if (area == null)
                return response.GetErrorResponse(Localization.NoDataFound);
            var responseDto = Mapper.Map<TextValueBindingResponseDto>(area);
            return response.GetSuccessResponse(responseDto, Localization.GeneralSuccess);
        }

        public async Task<ResponseDto<List<TextValueBindingResponseDto>>> GetAreas()
        {
            ResponseDto<List<TextValueBindingResponseDto>> response = new();
            var areas = await UnitOfWork.AreaRepository.GetAreas();
            if (areas.Count == default(int))
                return response.GetErrorResponse(Localization.NoDataFound);
            var responseDto = Mapper.Map<List<TextValueBindingResponseDto>>(areas);
            return response.GetSuccessResponse(responseDto, Localization.GeneralSuccess);
        }

        public async Task<ResponseDto<List<TextValueBindingResponseDto>>> GetAreasByCityId(int cityId)
        {
            ResponseDto<List<TextValueBindingResponseDto>> response = new();
            var areas = await UnitOfWork.AreaRepository.GetAreasByCityId(cityId);
            if (areas.Count == default(int))
                return response.GetErrorResponse(Localization.NoDataFound);
            var responseDto = Mapper.Map<List<TextValueBindingResponseDto>>(areas);
            return response.GetSuccessResponse(responseDto, Localization.GeneralSuccess);
        }
    }
}
