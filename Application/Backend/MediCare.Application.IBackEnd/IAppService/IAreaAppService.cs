using MediCare.Common.Dto;

namespace MediCare.IApplication.BackEnd.IAppService
{
    public interface IAreaAppService
    {
        Task<ResponseDto<TextValueBindingResponseDto>> GetArea(int areaId);
        Task<ResponseDto<List<TextValueBindingResponseDto>>> GetAreas();
        Task<ResponseDto<List<TextValueBindingResponseDto>>> GetAreasByCityId(int cityId);
    }
}
