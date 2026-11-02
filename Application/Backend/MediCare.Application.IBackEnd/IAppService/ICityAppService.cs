using MediCare.Common.Dto;

namespace MediCare.IApplication.BackEnd.IAppService
{
    public interface ICityAppService
    {
        Task<ResponseDto<TextValueBindingResponseDto>> GetCity(int cityId);
        Task<ResponseDto<List<TextValueBindingResponseDto>>> GetCities();
    }
}
