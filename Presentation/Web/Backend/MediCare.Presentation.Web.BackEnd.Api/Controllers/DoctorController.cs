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
            var response = await DoctorAppService.GetDoctors();
            if (response.Code != ResultStatusEnum.Success)
                return BadRequest(response);
            return Ok(response);
        }
        [HttpGet("specialization/{specializationId:int}")]
        public async Task<IActionResult> GetDoctorsBySpecializationId(int specializationId)
        {
            var response = await DoctorAppService.GetDoctorsBySpecializationId(specializationId);
            if (response.Code != ResultStatusEnum.Success)
                return BadRequest(response);
            return Ok(response);
        }
        [HttpGet("clinic/{clinicId:int}")]
        public async Task<IActionResult> GetDoctorsByClinicId(int clinicId)
        {
            var response = await DoctorAppService.GetDoctorsByClinicId(clinicId);
            if (response.Code != ResultStatusEnum.Success)
                return BadRequest(response);
            return Ok(response);
        }
        [HttpGet("clinic/{clinicId:int}/specialization/{specializationId:int}")]
        public async Task<IActionResult> GetDoctorsByClinicIdAndSpecializationId(int clinicId, int specializationId)
        {
            var response = await DoctorAppService.GetDoctorsByClinicIdAndSpecializationId(clinicId, specializationId);
            if (response.Code != ResultStatusEnum.Success)
                return BadRequest(response);
            return Ok(response);
        }
        [HttpGet("{doctorId:int}")]
        public async Task<IActionResult> GetDoctorById(int doctorId)
        {
            var response = await DoctorAppService.GetDoctorById(doctorId);
            if (response.Code != ResultStatusEnum.Success)
                return BadRequest(response);
            return Ok(response);
        }
        [HttpPost("CreateDoctor")]
        public async Task<IActionResult> CreateDoctor([FromBody] DoctorRequestDto doctorRequestDto)
        {
            var response = await DoctorAppService.CreateDoctor(doctorRequestDto);
            if (response.Code != ResultStatusEnum.Success)
                return BadRequest(response);
            return Ok(response);
        }
        [HttpPut("{doctorId:int}")]
        public async Task<IActionResult> UpdateDoctor(int doctorId, [FromBody] DoctorRequestDto doctorRequestDto)
        {
            doctorRequestDto.DoctorId = doctorId;
            var response = await DoctorAppService.UpdateDoctor(doctorRequestDto);
            if (response.Code != ResultStatusEnum.Success)
                return BadRequest(response);
            return Ok(response);
        }
        [HttpDelete("{doctorId:int}")]
        public async Task<IActionResult> DeleteDoctor(int doctorId)
        {
            var response = await DoctorAppService.DeleteDoctor(doctorId);
            if (response.Code != ResultStatusEnum.Success)
                return BadRequest(response);
            return Ok(response);
        }
        [HttpGet("{doctorId:int}/appointments")]
        public async Task<IActionResult> GetAppointmentsByDoctorId(int doctorId)
        {
            var response = await DoctorAppService.GetAppointmentsByDoctorId(doctorId);
            if (response.Code != ResultStatusEnum.Success)
                return BadRequest(response);
            return Ok(response);
        }
        [HttpGet("{doctorId:int}/slots")]
        public async Task<IActionResult> GetSlotsByDoctorId(int doctorId)
        {
            var response = await DoctorAppService.GetSlotsByDoctorId(doctorId);
            if (response.Code != ResultStatusEnum.Success)
                return BadRequest(response);
            return Ok(response);
        }
    }
}
