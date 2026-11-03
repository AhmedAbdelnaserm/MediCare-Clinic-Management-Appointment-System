using global::MediCare.Application.BackEnd.Dto.Dto.Paitient;
using global::MediCare.Common.Dto;
using global::MediCare.Common.Enum;
using global::MediCare.IApplication.BackEnd.IAppService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MediCare.Presentation.Web.BackEnd.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // All patient endpoints require a valid JWT
    public class PatientsController : ControllerBase
    {
        private readonly IPatientAppService _patientAppService;

        public PatientsController(IPatientAppService patientAppService)
        {
            _patientAppService = patientAppService;
        }

        /// <summary>Current authenticated user id (from the JWT "uid" claim).</summary>
        private string CurrentUserId =>
            User.FindFirstValue("uid")
            ?? User.FindFirstValue(ClaimTypes.NameIdentifier)
            ?? string.Empty;

        private bool IsAdminOrDoctor =>
            User.IsInRole("Admin") || User.IsInRole("Doctor");

        /// <summary>Admin/Doctor only: list all patient profiles.</summary>
        [HttpGet]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<ActionResult<ResponseDto<IEnumerable<PatientDto>>>> GetAll()
        {
            var response = await _patientAppService.GetAllAsync();
            if (response.Code != ResultStatusEnum.Success)
                return BadRequest(response);
            return Ok(response);
        }

        /// <summary>Admin/Doctor: any profile. Patient: only their own profile.</summary>
        [HttpGet("{patientId:int}")]
        public async Task<ActionResult<ResponseDto<PatientDto>>> GetById(int patientId)
        {
            var response = await _patientAppService.GetByIdAsync(patientId);
            if (response.Code != ResultStatusEnum.Success)
                return NotFound(response);

            // Patients may only view their own profile
            if (!IsAdminOrDoctor && response.Data?.UserId != CurrentUserId)
                return Forbid();

            return Ok(response);
        }

        /// <summary>Patient: own profile without knowing its id.</summary>
        [HttpGet("me")]
        [Authorize(Roles = "Admin,Doctor,Patient")]
        public async Task<ActionResult<ResponseDto<PatientDto>>> GetMyProfile()
        {
            var response = await _patientAppService.GetMyProfileAsync(CurrentUserId);
            if (response.Code != ResultStatusEnum.Success)
                return NotFound(response);
            return Ok(response);
        }

        /// <summary>Patient: creates own profile. Admin: may create for any user (pass UserId).</summary>
        [HttpPost]
        [Authorize(Roles = "Admin,Patient")]
        public async Task<ActionResult<ResponseDto<PatientDto>>> Create([FromBody] CreatePatientDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // A Patient account may only create its own profile
            if (!IsAdminOrDoctor)
                dto.UserId = CurrentUserId;

            var response = await _patientAppService.CreateAsync(dto, CurrentUserId);
            if (response.Code != ResultStatusEnum.Success)
                return BadRequest(response);

            return CreatedAtAction(nameof(GetById), new { patientId = response.Data.PatientId }, response);
        }

        /// <summary>Patient: own profile only. Admin/Doctor: any profile.</summary>
        [HttpPut("{patientId:int}")]
        public async Task<ActionResult<ResponseDto<PatientDto>>> Update(int patientId, [FromBody] UpdatePatientDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            dto.PatientId = patientId;

            var response = await _patientAppService.UpdateAsync(dto, CurrentUserId);
            if (response.Code != ResultStatusEnum.Success)
                return BadRequest(response);

            return Ok(response);
        }

        /// <summary>Patient: own profile only. Admin: any profile.</summary>
        [HttpDelete("{patientId:int}")]
        public async Task<ActionResult<ResponseDto<bool>>> Delete(int patientId)
        {
            var response = await _patientAppService.DeleteAsync(patientId, CurrentUserId);
            if (response.Code != ResultStatusEnum.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
