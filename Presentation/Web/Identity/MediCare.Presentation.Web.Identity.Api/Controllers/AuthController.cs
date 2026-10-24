using MediCare.Application.Identity.Dto.Authentication;
using MediCare.IApplication.Identity.IAppService;
using Microsoft.AspNetCore.Mvc;

namespace MediCare.Presentation.Web.Identity.Api.Controllers
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
        public async Task<IActionResult> Register([FromBody] RegisterDto request)
        {
            if (!ModelState.IsValid)
                return Ok(ModelState);
            var response = await AuthService.UserRegister(request);
            return Ok(response);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            if (!ModelState.IsValid)
                return Ok(ModelState);
            var response = await AuthService.UserLogin(request);
            return Ok(response);
        }
    }
}
