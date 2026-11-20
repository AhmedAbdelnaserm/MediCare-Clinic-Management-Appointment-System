using MediCare.Common.Enum;
using MediCare.IApplication.BackEnd.IAppService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediCare.Presentation.Web.Frontend.Mvc.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = nameof(UserRolesEnum.ClinicAdmin))]
public sealed class AppointmentsController : Controller
{
    private readonly IClinicAppointmentService _appointmentService;

    public AppointmentsController(IClinicAppointmentService appointmentService) =>
        _appointmentService = appointmentService;

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var response = await _appointmentService.GetAppointments();
        if (response.Code != ResultStatusEnum.Success)
        {
            ViewBag.Error = response.Message;
            return View(Array.Empty<MediCare.Application.BackEnd.Dto.AppointmentDto.ClinicAppointmentDto>());
        }

        return View(response.Data ?? []);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Cancel(int appointmentId, string? reason)
    {
        var response = await _appointmentService.Cancel(appointmentId, reason);
        TempData[response.Code == ResultStatusEnum.Success ? "Success" : "Error"] = response.Message;
        return RedirectToAction(nameof(Index));
    }
}
