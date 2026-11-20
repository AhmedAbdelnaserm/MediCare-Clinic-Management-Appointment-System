using MediCare.Application.BackEnd.Dto.AppointmentDto;
using MediCare.Common.Dto;
using MediCare.Common.Enum;
using MediCare.IApplication.BackEnd.IAppService;
using MediCare.Presentation.Web.Frontend.Mvc.Areas.SuperAdmin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MediCare.Presentation.Web.Frontend.Mvc.Areas.SuperAdmin.Controllers;

[Area("SuperAdmin")]
[Authorize(Roles = nameof(UserRolesEnum.SuperAdmin))]
public sealed class SchedulesController : Controller
{
    private readonly IClinicScheduleService _scheduleService;
    private readonly IDoctorService _doctorService;
    private readonly IClinicAppService _clinicService;

    public SchedulesController(
        IClinicScheduleService scheduleService,
        IDoctorService doctorService,
        IClinicAppService clinicService)
    {
        _scheduleService = scheduleService;
        _doctorService = doctorService;
        _clinicService = clinicService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        await LoadFormOptions();
        ViewBag.Links = (await _scheduleService.GetClinicDoctorLinks()).Data ?? [];
        return View(new CreateClinicDoctorScheduleDto { ConsultationDurationMinutes = 30 });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Assign(CreateClinicDoctorScheduleDto model)
    {
        if (!ModelState.IsValid)
        {
            await LoadFormOptions();
            ViewBag.Links = (await _scheduleService.GetClinicDoctorLinks()).Data ?? [];
            return View("Index", model);
        }

        var response = await _scheduleService.CreateClinicDoctorLink(model);
        if (response.Code != ResultStatusEnum.Success || response.Data <= 0)
        {
            ModelState.AddModelError(string.Empty, response.Message);
            await LoadFormOptions();
            ViewBag.Links = (await _scheduleService.GetClinicDoctorLinks()).Data ?? [];
            return View("Index", model);
        }

        TempData["Success"] = "Doctor assigned to clinic. Set weekly availability next.";
        return RedirectToAction(nameof(Configure), new { id = response.Data });
    }

    [HttpGet]
    public async Task<IActionResult> Configure(int id)
    {
        if (id <= 0)
            return BadRequest();

        var schedule = await _scheduleService.GetClinicDoctorSchedule(id);
        if (schedule.Code != ResultStatusEnum.Success || schedule.Data is null)
            return NotFound();

        var persistedHours = schedule.Data.WorkingHours;
        var isNew = persistedHours.Count == 0;
        var viewModel = new ClinicDoctorScheduleViewModel
        {
            ClinicDoctorId = id,
            WorkingHours = Enum.GetValues<DayOfWeek>().SelectMany(day => Enumerable.Range(0, 2)
                .Select(shift =>
                {
                    var persisted = persistedHours.Where(hour => hour.DayOfWeek == (int)day)
                        .OrderBy(hour => hour.StartTime).Skip(shift).FirstOrDefault();
                    return new WorkingHourRowViewModel
                    {
                        DayOfWeek = (int)day,
                        DayName = day.ToString(),
                        ShiftName = shift == 0 ? "Shift 1" : "Shift 2",
                        IsWorking = persisted is not null ||
                                    (isNew && shift == 0 && day is not DayOfWeek.Saturday and not DayOfWeek.Friday),
                        StartTime = persisted?.StartTime ?? (shift == 0 ? new TimeOnly(9, 0) : new TimeOnly(14, 0)),
                        EndTime = persisted?.EndTime ?? (shift == 0 ? new TimeOnly(13, 0) : new TimeOnly(17, 0))
                    };
                })).ToList()
        };
        viewModel.Exceptions = (await _scheduleService.GetScheduleExceptions(id, DateOnly.FromDateTime(DateTime.UtcNow), DateOnly.FromDateTime(DateTime.UtcNow.AddDays(365)))).Data ?? [];
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SaveHours(ClinicDoctorScheduleViewModel model)
    {
        if (model.ClinicDoctorId <= 0)
            return BadRequest();

        var hours = model.WorkingHours.Where(hour => hour.IsWorking).Select(hour => new WorkingHourDto
        {
            DayOfWeek = hour.DayOfWeek,
            StartTime = hour.StartTime,
            EndTime = hour.EndTime
        }).ToList();

        var response = await _scheduleService.ReplaceWorkingHours(
            model.ClinicDoctorId,
            new ReplaceWorkingHoursDto { WorkingHours = hours });

        TempData[response.Code == ResultStatusEnum.Success ? "Success" : "Error"] = response.Message;
        return RedirectToAction(nameof(Configure), new { id = model.ClinicDoctorId });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Generate(ClinicDoctorScheduleViewModel model)
    {
        if (model.ClinicDoctorId <= 0)
            return BadRequest();

        var response = await _scheduleService.GenerateSlots(model.ClinicDoctorId, new GenerateSlotsDto
        {
            StartDate = model.StartDate,
            EndDate = model.EndDate
        });

        TempData[response.Code == ResultStatusEnum.Success ? "Success" : "Error"] = response.Code == ResultStatusEnum.Success
            ? $"Generated {response.Data?.CreatedCount ?? 0} appointment times."
            : response.Message;
        return RedirectToAction(nameof(Configure), new { id = model.ClinicDoctorId });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SaveException(ClinicDoctorScheduleViewModel model)
    {
        if (model.ClinicDoctorId <= 0)
            return BadRequest();
        var result = await _scheduleService.SaveScheduleException(model.ClinicDoctorId, new SaveScheduleExceptionDto
        {
            ExceptionDate = model.ExceptionDate,
            IsClosed = model.ExceptionIsClosed,
            StartTime = model.ExceptionIsClosed ? null : model.ExceptionStartTime,
            EndTime = model.ExceptionIsClosed ? null : model.ExceptionEndTime,
            Reason = model.ExceptionReason
        });
        TempData[result.Code == ResultStatusEnum.Success ? "Success" : "Error"] = result.Message;
        return RedirectToAction(nameof(Configure), new { id = model.ClinicDoctorId });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteException(int id, int exceptionId)
    {
        if (id <= 0 || exceptionId <= 0)
            return BadRequest();
        var result = await _scheduleService.DeleteScheduleException(id, exceptionId);
        TempData[result.Code == ResultStatusEnum.Success ? "Success" : "Error"] = result.Message;
        return RedirectToAction(nameof(Configure), new { id });
    }

    private async Task LoadFormOptions()
    {
        var clinics = await _clinicService.GetClinics();
        var doctors = await _doctorService.GetDoctors();
        ViewBag.Clinics = (clinics.Data ?? []).Select(item => new SelectListItem(item.Name, item.Id.ToString())).ToList();
        ViewBag.Doctors = (doctors.Data ?? []).Select(item => new SelectListItem(
            $"Dr. {item.DoctorName} — {item.SpecializationName}", item.DoctorId.ToString())).ToList();
    }
}
