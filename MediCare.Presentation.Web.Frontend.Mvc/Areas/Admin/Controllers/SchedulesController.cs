using MediCare.Application.BackEnd.Dto.AppointmentDto;
using MediCare.Application.Identity.Dto.ClinicAdminDto;
using MediCare.Common.Enum;
using MediCare.Common.ExtensionMethod;
using MediCare.IApplication.BackEnd.IAppService;
using MediCare.IApplication.Identity.IAppService;
using MediCare.Presentation.Web.Frontend.Mvc.Areas.SuperAdmin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediCare.Presentation.Web.Frontend.Mvc.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = nameof(UserRolesEnum.ClinicAdmin))]
public sealed class SchedulesController : Controller
{
    private readonly IClinicScheduleService _scheduleService;
    private readonly IClinicAdminAppService _clinicAdminService;

    public SchedulesController(IClinicScheduleService scheduleService, IClinicAdminAppService clinicAdminService)
    {
        _scheduleService = scheduleService;
        _clinicAdminService = clinicAdminService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var clinicId = await GetMyClinicId();
        if (clinicId is null)
            return Forbid();

        var linksResponse = await _scheduleService.GetClinicDoctorLinks();
        var links = (linksResponse.Data ?? []).Where(link => link.ClinicId == clinicId.Value).ToList();
        return View(links);
    }

    [HttpGet]
    public async Task<IActionResult> Configure(int id)
    {
        var link = await GetOwnedLink(id);
        if (link is null)
            return Forbid();

        var schedule = await _scheduleService.GetClinicDoctorSchedule(id);
        if (schedule.Data is null)
            return NotFound();

        var persisted = schedule.Data.WorkingHours;
        var isNew = persisted.Count == 0;
        var viewModel = new ClinicDoctorScheduleViewModel
        {
            ClinicDoctorId = id,
            WorkingHours = Enum.GetValues<DayOfWeek>().SelectMany(day => Enumerable.Range(0, 2)
                .Select(shift =>
                {
                    var item = persisted.Where(hour => hour.DayOfWeek == (int)day)
                        .OrderBy(hour => hour.StartTime).Skip(shift).FirstOrDefault();
                    return new WorkingHourRowViewModel
                    {
                        DayOfWeek = (int)day,
                        DayName = day.ToString(),
                        ShiftName = shift == 0 ? "Shift 1" : "Shift 2",
                        IsWorking = item is not null ||
                            (isNew && shift == 0 && day is not DayOfWeek.Saturday and not DayOfWeek.Friday),
                        StartTime = item?.StartTime ?? (shift == 0 ? new TimeOnly(9, 0) : new TimeOnly(14, 0)),
                        EndTime = item?.EndTime ?? (shift == 0 ? new TimeOnly(13, 0) : new TimeOnly(17, 0))
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
        if (await GetOwnedLink(model.ClinicDoctorId) is null)
            return Forbid();

        var hours = model.WorkingHours.Where(hour => hour.IsWorking).Select(hour => new WorkingHourDto
        {
            DayOfWeek = hour.DayOfWeek,
            StartTime = hour.StartTime,
            EndTime = hour.EndTime
        }).ToList();
        var response = await _scheduleService.ReplaceWorkingHours(
            model.ClinicDoctorId, new ReplaceWorkingHoursDto { WorkingHours = hours });
        TempData[response.Code == ResultStatusEnum.Success ? "Success" : "Error"] = response.Message;
        return RedirectToAction(nameof(Configure), new { id = model.ClinicDoctorId });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Generate(ClinicDoctorScheduleViewModel model)
    {
        if (await GetOwnedLink(model.ClinicDoctorId) is null)
            return Forbid();

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
        if (await GetOwnedLink(model.ClinicDoctorId) is null)
            return Forbid();
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
        if (await GetOwnedLink(id) is null)
            return Forbid();
        var result = await _scheduleService.DeleteScheduleException(id, exceptionId);
        TempData[result.Code == ResultStatusEnum.Success ? "Success" : "Error"] = result.Message;
        return RedirectToAction(nameof(Configure), new { id });
    }

    private async Task<int?> GetMyClinicId()
    {
        var userId = User.GetUserId();
        if (string.IsNullOrWhiteSpace(userId))
            return null;

        var response = await _clinicAdminService.GetClinicAdmin(userId);
        return response.Code == ResultStatusEnum.Success ? response.Data?.ClinicId : null;
    }

    private async Task<ClinicDoctorScheduleSummaryDto?> GetOwnedLink(int clinicDoctorId)
    {
        var clinicId = await GetMyClinicId();
        if (clinicId is null)
            return null;

        var response = await _scheduleService.GetClinicDoctorLinks();
        return response.Data?.FirstOrDefault(link =>
            link.ClinicDoctorId == clinicDoctorId && link.ClinicId == clinicId.Value);
    }
}
