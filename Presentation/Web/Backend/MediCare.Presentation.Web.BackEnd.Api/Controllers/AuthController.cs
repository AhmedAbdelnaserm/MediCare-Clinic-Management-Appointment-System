using MediCare.Application.Identity.Dto.Authentication;
using MediCare.IApplication.Identity.IAppService;
using Microsoft.AspNetCore.Mvc;

namespace MediCare.Presentation.Web.BackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            return Ok(await AuthService.UserRegister(request));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto request)
        {
            return Ok(await AuthService.UserLogin(request));
        }
    }
}
