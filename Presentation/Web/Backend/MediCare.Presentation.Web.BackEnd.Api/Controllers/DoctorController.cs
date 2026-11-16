using MediCare.IApplication.BackEnd.IAppService;
using MediCare.Application.BackEnd.Dto.Dto;
using MediCare.Common.Enum;
using Microsoft.AspNetCore.Mvc;

namespace MediCare.Presentation.Web.BackEnd.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService DoctorAppService;

        public DoctorController(IDoctorService doctorAppService)
        {
            DoctorAppService = doctorAppService;
        }
       [HttpGet("GetDoctors") ]
       public async Task<IActionResult> GetDoctors()
        {
            return Ok(await DoctorAppService.GetDoctors());
        }
        [HttpGet("specialization/{specializationId:int}")]
        public async Task<IActionResult> GetDoctorsBySpecializationId(int specializationId)
        {
           return Ok(await DoctorAppService.GetDoctorsBySpecializationId(specializationId));
        }
     
        [HttpGet("{doctorId:int}")]
        public async Task<IActionResult> GetDoctorById(int doctorId)
        {
           return Ok(await DoctorAppService.GetDoctorById(doctorId));
        }
        [HttpPost("CreateDoctor")]
        public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorRequestDto doctorRequestDto)
        {
           return Ok(await DoctorAppService.CreateDoctor(doctorRequestDto));
        }
        [HttpPut("{doctorId:int}")]
        public async Task<IActionResult> UpdateDoctor(int doctorId, [FromBody] UpdateDoctorRequestDto? doctorRequestDto)
        {
           return Ok(await DoctorAppService.UpdateDoctor(doctorId, doctorRequestDto));
        }
        [HttpDelete("{doctorId:int}")]
        public async Task<IActionResult> DeleteDoctor(int doctorId)
        {
          return Ok(await DoctorAppService.DeleteDoctor(doctorId));
        }
    }
}
