using MediCare.Presentation.Shared.Extensions;
using MediCare.Application.Identity.Dto.Authentication;
using MediCare.IApplication.Identity.IAppService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MediCare.Presentation.Web.Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService AuthService;
        public AuthController(IAuthService authService)
        {
            AuthService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto request)
        {
            return this.ToHttpResult(await AuthService.UserRegister(request));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto request)
        {
            return this.ToHttpResult(await AuthService.UserLogin(request));
        }
    }
}
