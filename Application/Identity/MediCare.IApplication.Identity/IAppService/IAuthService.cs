using MediCare.Application.Identity.Dto.Authentication;
using MediCare.Common.Dto;

namespace MediCare.IApplication.Identity.IAppService
{
    public interface IAuthService
    {
        Task<ResponseDto<AuthModel>> UserRegister(RegisterDto request);
        Task<ResponseDto<AuthModel>> UserLogin(LoginDto model);
        
    }
}
