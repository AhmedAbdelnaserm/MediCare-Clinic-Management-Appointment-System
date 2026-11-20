using MediCare.Application.BackEnd.Dto.AppointmentDto;
using MediCare.Common.Enum;
using MediCare.IApplication.BackEnd.IAppService;
using MediCare.Presentation.Shared.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediCare.Presentation.Web.BackEnd.Api.Controllers;

[ApiController]
[Route("api/clinic-schedules")]
[Authorize(Roles = nameof(UserRolesEnum.SuperAdmin))]
public sealed class ClinicSchedulesController : ControllerBase
{
    private readonly IClinicScheduleService _scheduleService;

    public ClinicSchedulesController(IClinicScheduleService scheduleService) => _scheduleService = scheduleService;

    [HttpPost("clinic-doctors")]
    public async Task<IActionResult> CreateClinicDoctorLink(
        [FromBody] CreateClinicDoctorScheduleDto request) =>
        this.ToHttpResult(await _scheduleService.CreateClinicDoctorLink(request));

    [HttpPut("clinic-doctors/{clinicDoctorId:int}/working-hours")]
    public async Task<IActionResult> ReplaceWorkingHours(
        int clinicDoctorId,
        [FromBody] ReplaceWorkingHoursDto request) =>
        this.ToHttpResult(await _scheduleService.ReplaceWorkingHours(clinicDoctorId, request));

    [HttpPost("clinic-doctors/{clinicDoctorId:int}/generate-slots")]
    public async Task<IActionResult> GenerateSlots(
        int clinicDoctorId,
        [FromBody] GenerateSlotsDto request) =>
        this.ToHttpResult(await _scheduleService.GenerateSlots(clinicDoctorId, request));

    [HttpGet("clinic-doctors/{clinicDoctorId:int}/exceptions")]
    public async Task<IActionResult> GetExceptions(int clinicDoctorId, [FromQuery] DateOnly startDate, [FromQuery] DateOnly endDate) =>
        this.ToHttpResult(await _scheduleService.GetScheduleExceptions(clinicDoctorId, startDate, endDate));

    [HttpPut("clinic-doctors/{clinicDoctorId:int}/exceptions")]
    public async Task<IActionResult> SaveException(int clinicDoctorId, [FromBody] SaveScheduleExceptionDto request) =>
        this.ToHttpResult(await _scheduleService.SaveScheduleException(clinicDoctorId, request));

    [HttpDelete("clinic-doctors/{clinicDoctorId:int}/exceptions/{exceptionId:int}")]
    public async Task<IActionResult> DeleteException(int clinicDoctorId, int exceptionId) =>
        this.ToHttpResult(await _scheduleService.DeleteScheduleException(clinicDoctorId, exceptionId));
}
