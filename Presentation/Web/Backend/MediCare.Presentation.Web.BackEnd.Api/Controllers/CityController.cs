using MediCare.Presentation.Shared.Extensions;
using MediCare.IApplication.BackEnd.IAppService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MediCare.Presentation.Web.BackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CityController : ControllerBase
    {
        private readonly ICityAppService CityAppService;

        public CityController(ICityAppService cityAppService)
        {
            CityAppService = cityAppService;
        }

        [HttpGet("{cityId}")]
        public async Task<IActionResult> GetCity(int cityId)
        {
            return this.ToHttpResult(await CityAppService.GetCity(cityId));
        }

        [HttpGet("GetCities")]
        public async Task<IActionResult> GetCities()
        {
            return this.ToHttpResult(await CityAppService.GetCities());
        }
    }
}
