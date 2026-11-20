using MediCare.Application.BackEnd.Base;
using MediCare.Application.BackEnd.Localization;
using MediCare.Common.Dto;
using MediCare.Common.Interface;
using MediCare.Core.IRepository.IUnitOfWork;
using MediCare.IApplication.BackEnd.IAppService;
using Microsoft.Extensions.Logging;

namespace MediCare.Application.BackEnd.AppService
{
    public class CityAppService : BaseAppService, ICityAppService
    {
        public CityAppService(ILocalizationService localization, ILogger<CityAppService> logger, IUnitOfWork unitOfWork, ICurrentUserService currentUser)
            : base(localization, logger, unitOfWork, currentUser)
        {
        }

        public async Task<ResponseDto<TextValueBindingResponseDto>> GetCity(int cityId)
        {
            ResponseDto<TextValueBindingResponseDto> response = new();
            if (cityId <= 0)
                return response.GetErrorResponse(Localization.InvalidData);
            var city = await UnitOfWork.CityRepository.GetCity(cityId);
            if (city == null)
                return response.GetErrorResponse(Localization.NoDataFound);
            var responseDto = new TextValueBindingResponseDto { Id = city.CityId, Name = city.EnName };
            return response.GetSuccessResponse(responseDto, Localization.GeneralSuccess);
        }
        public async Task<ResponseDto<List<TextValueBindingResponseDto>>> GetCities()
        {
            ResponseDto<List<TextValueBindingResponseDto>> response = new();
            var city = await UnitOfWork.CityRepository.GetCities();
            if (city.Count == default(int))
                return response.GetErrorResponse(Localization.NoDataFound);
            var responseDto = city.Select(item => new TextValueBindingResponseDto { Id = item.CityId, Name = item.EnName }).ToList();
            return response.GetSuccessResponse(responseDto, Localization.GeneralSuccess);
        }


    }
}
