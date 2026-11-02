using MediCare.IApplication.BackEnd.IAppService;
using Microsoft.AspNetCore.Mvc;

namespace MediCare.Presentation.Web.BackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            return Ok(await CityAppService.GetCity(cityId));
        }

        [HttpGet("GetCities")]
        public async Task<IActionResult> GetCities()
        {
            return Ok(await CityAppService.GetCities());
        }
    }
}
