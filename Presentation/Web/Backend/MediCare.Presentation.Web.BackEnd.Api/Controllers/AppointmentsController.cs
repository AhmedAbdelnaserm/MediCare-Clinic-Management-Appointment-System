using MediCare.Application.BackEnd.Dto.AppointmentDto;
using MediCare.Common.Enum;
using MediCare.IApplication.BackEnd.IAppService;
using MediCare.Presentation.Shared.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediCare.Presentation.Web.BackEnd.Api.Controllers;

[ApiController]
[Route("api/appointments")]
[Authorize(Roles = nameof(UserRolesEnum.Patient))]
public sealed class AppointmentsController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentsController(IAppointmentService appointmentService) => _appointmentService = appointmentService;

    [HttpGet("available")]
    public async Task<IActionResult> GetAvailable([FromQuery] int? doctorId) =>
        this.ToHttpResult(await _appointmentService.GetAvailableSlots(doctorId));

    [HttpGet("mine")]
    public async Task<IActionResult> GetMine() =>
        this.ToHttpResult(await _appointmentService.GetMyAppointments());

    [HttpPost]
    public async Task<IActionResult> Book([FromBody] BookAppointmentRequestDto request) =>
        this.ToHttpResult(await _appointmentService.Book(request.SlotId));

    [HttpPost("{appointmentId:int}/cancel")]
    public async Task<IActionResult> Cancel(
        int appointmentId,
        [FromBody] CancelAppointmentRequestDto request) =>
        this.ToHttpResult(await _appointmentService.Cancel(appointmentId, request.Reason));

    [HttpPost("{appointmentId:int}/reschedule")]
    public async Task<IActionResult> Reschedule(
        int appointmentId,
        [FromBody] RescheduleAppointmentRequestDto request) =>
        this.ToHttpResult(await _appointmentService.Reschedule(appointmentId, request.SlotId));
}
