using MediCare.Presentation.Shared.Extensions;

using MediCare.Application.BackEnd.Dto.ClinicDto;
using MediCare.IApplication.BackEnd.IAppService;
using MediCare.Common.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediCare.Presentation.Web.BackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClinicController : ControllerBase
    {
        private readonly IClinicAppService ClinicAppService;

        public ClinicController(IClinicAppService clinicAppService)
        {
            ClinicAppService = clinicAppService;
        }

        [HttpGet("{clinicId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetClinic(int clinicId)
        {
            return this.ToHttpResult(await ClinicAppService.GetClinic(clinicId));
        }

        [HttpGet("GetClinics")]
        [AllowAnonymous]
        public async Task<IActionResult> GetClinics()
        {
            return this.ToHttpResult(await ClinicAppService.GetClinics());
        }

        [HttpGet("GetClinic/{areaId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetClinicsByAreaId(int areaId)
        {
            return this.ToHttpResult(await ClinicAppService.GetClinicsByAreaId(areaId));
        }


        [HttpPost("CreateClinic")]
        [Authorize(Roles = nameof(UserRolesEnum.SuperAdmin))]
        public async Task<IActionResult> CreateClinic([FromBody] CreateClinicRequestDto clinicDto)
        {
            return this.ToHttpResult(await ClinicAppService.CreateClinic(clinicDto));
        }

        [HttpPut("UpdateClinic/{clinicId}")]
        [Authorize(Roles = nameof(UserRolesEnum.SuperAdmin))]
        public async Task<IActionResult> UpdateClinic(int clinicId, [FromBody] UpdateClinicRequestDto clinicDto)
        {
            return this.ToHttpResult(await ClinicAppService.UpdateClinic(clinicId, clinicDto));
        }

        [HttpDelete("DeleteClinic/{clinicId}")]
        [Authorize(Roles = nameof(UserRolesEnum.SuperAdmin))]
        public async Task<IActionResult> DeleteClinic(int clinicId)
        {
            return this.ToHttpResult(await ClinicAppService.DeleteClinic(clinicId));
        }

    }
}
