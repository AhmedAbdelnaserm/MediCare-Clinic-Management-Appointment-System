using MediCare.Presentation.Shared.Extensions;
using MediCare.IApplication.BackEnd.IAppService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MediCare.Presentation.Web.BackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
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
            return this.ToHttpResult(await AreaAppService.GetArea(areaId));
        }

        [HttpGet("GetAreas")]
        public async Task<IActionResult> GetAreas()
        {
            return this.ToHttpResult(await AreaAppService.GetAreas());
        }

        [HttpGet("GetAreas/{cityId}")]
        public async Task<IActionResult> GetAreasByCityId(int cityId)
        {
            return this.ToHttpResult(await AreaAppService.GetAreasByCityId(cityId));
        }
    }
}
