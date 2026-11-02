using MediCare.IApplication.BackEnd.IAppService;
using Microsoft.AspNetCore.Mvc;

namespace MediCare.Presentation.Web.BackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IAreaAppService AreaAppService;
        public AreaController(IAreaAppService areaAppService)
        {
            AreaAppService = areaAppService;
        }

        [HttpGet("{areaId}")]
        public async Task<IActionResult> GetArea(int areaId)
        {
            return Ok(await AreaAppService.GetArea(areaId));
        }

        [HttpGet("GetAreas")]
        public async Task<IActionResult> GetAreas()
        {
            return Ok(await AreaAppService.GetAreas());
        }

        [HttpGet("GetAreas/{cityId}")]
        public async Task<IActionResult> GetAreasByCityId(int cityId)
        {
            return Ok(await AreaAppService.GetAreasByCityId(cityId));
        }
    }
}
