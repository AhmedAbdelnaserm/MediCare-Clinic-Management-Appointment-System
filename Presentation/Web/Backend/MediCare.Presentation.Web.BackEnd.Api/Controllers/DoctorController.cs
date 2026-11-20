using MediCare.Presentation.Shared.Extensions;
using MediCare.IApplication.BackEnd.IAppService;
using MediCare.Common.Enum;
using Microsoft.AspNetCore.Mvc;
using MediCare.Application.BackEnd.Dto.DoctorDto;
using Microsoft.AspNetCore.Authorization;

namespace MediCare.Presentation.Web.BackEnd.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
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
            return this.ToHttpResult(await DoctorAppService.GetDoctors());
        }
        [HttpGet("specialization/{specializationId:int}")]
        public async Task<IActionResult> GetDoctorsBySpecializationId(int specializationId)
        {
           return this.ToHttpResult(await DoctorAppService.GetDoctorsBySpecializationId(specializationId));
        }
     
        [HttpGet("{doctorId:int}")]
        public async Task<IActionResult> GetDoctorById(int doctorId)
        {
           return this.ToHttpResult(await DoctorAppService.GetDoctorById(doctorId));
        }
        [HttpPost("CreateDoctor")]
        [Authorize(Roles = nameof(UserRolesEnum.SuperAdmin))]
        public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorRequestDto doctorRequestDto)
        {
           return this.ToHttpResult(await DoctorAppService.CreateDoctor(doctorRequestDto));
        }
        [HttpPut("{doctorId:int}")]
        [Authorize(Roles = nameof(UserRolesEnum.SuperAdmin))]
        public async Task<IActionResult> UpdateDoctor(int doctorId, [FromBody] UpdateDoctorRequestDto doctorRequestDto)
        {
           return this.ToHttpResult(await DoctorAppService.UpdateDoctor(doctorId, doctorRequestDto));
        }
        [HttpDelete("{doctorId:int}")]
        [Authorize(Roles = nameof(UserRolesEnum.SuperAdmin))]
        public async Task<IActionResult> DeleteDoctor(int doctorId)
        {
          return this.ToHttpResult(await DoctorAppService.DeleteDoctor(doctorId));
        }
    }
}
