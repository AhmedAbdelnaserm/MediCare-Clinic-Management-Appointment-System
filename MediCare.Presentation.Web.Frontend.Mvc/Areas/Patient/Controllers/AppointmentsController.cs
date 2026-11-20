using MediCare.Common.Enum;
using MediCare.IApplication.BackEnd.IAppService;
using MediCare.Presentation.Web.Frontend.Mvc.Areas.Patient.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MediCare.Presentation.Web.Frontend.Mvc.Areas.Patient.Controllers;

[Area("Patient")]
[Authorize(Roles = nameof(UserRolesEnum.Patient))]
public sealed class AppointmentsController : Controller
{
    private readonly IAppointmentService _appointmentService;
    private readonly IDoctorService _doctorService;

    public AppointmentsController(IAppointmentService appointmentService, IDoctorService doctorService)
    {
        _appointmentService = appointmentService;
        _doctorService = doctorService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(int? doctorId)
    {
        var slotsResponse = await _appointmentService.GetAvailableSlots(doctorId);
        var appointmentsResponse = await _appointmentService.GetMyAppointments();
        var doctorsResponse = await _doctorService.GetDoctors();
        var doctors = doctorsResponse.Data ?? [];

        if (!string.IsNullOrWhiteSpace(slotsResponse.Message) && slotsResponse.Code != ResultStatusEnum.Success)
            TempData["AppointmentError"] = slotsResponse.Message;
        if (appointmentsResponse.Code != ResultStatusEnum.Success)
            TempData["AppointmentError"] = appointmentsResponse.Message;

        var model = new AppointmentsViewModel
        {
            DoctorId = doctorId,
            Doctors = doctors.Select(doctor => new SelectListItem(
                $"Dr. {doctor.DoctorName} — {doctor.SpecializationName}",
                doctor.DoctorId.ToString(),
                doctorId == doctor.DoctorId)).ToList(),
            AvailableSlots = slotsResponse.Data ?? [],
            MyAppointments = appointmentsResponse.Data ?? []
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Book(int slotId)
    {
        var response = await _appointmentService.Book(slotId);
        TempData[response.Code == ResultStatusEnum.Success ? "AppointmentMessage" : "AppointmentError"] = response.Message;
        return RedirectToAction(nameof(Index), new { doctorId = response.Data?.DoctorId });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Cancel(int appointmentId, string? reason)
    {
        var response = await _appointmentService.Cancel(appointmentId, reason);
        TempData[response.Code == ResultStatusEnum.Success ? "AppointmentMessage" : "AppointmentError"] = response.Message;
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Reschedule(int appointmentId, int slotId)
    {
        var response = await _appointmentService.Reschedule(appointmentId, slotId);
        TempData[response.Code == ResultStatusEnum.Success ? "AppointmentMessage" : "AppointmentError"] = response.Message;
        return RedirectToAction(nameof(Index));
    }
}
