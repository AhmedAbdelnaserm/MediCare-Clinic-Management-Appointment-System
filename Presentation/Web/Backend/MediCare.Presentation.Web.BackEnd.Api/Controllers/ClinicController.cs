
using MediCare.Common.Dto;
using MediCare.IApplication.BackEnd.IAppService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediCare.Presentation.Web.BackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly IClinicAppService ClinicAppService;

        public ClinicController(IClinicAppService clinicAppService)
        {
            ClinicAppService = clinicAppService;
        }

        [HttpGet("{clinicId}")]
        public async Task<IActionResult> GetClinic(int clinicId)
        {
            return Ok(await ClinicAppService.GetClinic(clinicId));
        }

        [HttpGet("GetClinics")]
        public async Task<IActionResult> GetClinics()
        {
            return Ok(await ClinicAppService.GetClinics());
        }

        [HttpGet("GetClinicsByAreaId/{areaId}")]
        public async Task<IActionResult> GetClinicsByAreaId(int areaId)
        {
            return Ok(await ClinicAppService.GetClinicsByAreaId(areaId));
        }


        [HttpPost("CreateClinic")]
        public async Task<IActionResult> CreateClinic([FromBody] CreateClinicRequestDto clinicDto)
        {
            return Ok(await ClinicAppService.CreateClinic(clinicDto));
        }

        [HttpPut("UpdateClinic/{clinicId}")]
        public async Task<IActionResult> UpdateClinic(int clinicId, [FromBody] CreateClinicRequestDto clinicDto)
        {
            return Ok(await ClinicAppService.UpdateClinic(clinicId, clinicDto));
        }

        [HttpDelete("DeleteClinic/{clinicId}")]
        public async Task<IActionResult> DeleteClinic(int clinicId)
        {
            return Ok(await ClinicAppService.DeleteClinic(clinicId));
        }

    }
}
