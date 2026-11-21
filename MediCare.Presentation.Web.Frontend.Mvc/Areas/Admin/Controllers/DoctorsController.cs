using MediCare.Application.BackEnd.Dto.ClinicDoctorDto;
using MediCare.Application.BackEnd.Dto.ClinicDto;
using MediCare.Application.BackEnd.Dto.DoctorDto;
using MediCare.Common.Enum;
using MediCare.IApplication.BackEnd.IAppService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediCare.Presentation.Web.Frontend.Mvc.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = nameof(UserRolesEnum.ClinicAdmin))]
public class DoctorsController : Controller
{
    private readonly IClinicDoctorAppService ClinicDoctorService;

    public DoctorsController(IClinicDoctorAppService clinicDoctorService)
    {
        ClinicDoctorService = clinicDoctorService;
    }

    public async Task<IActionResult> Index()
    {
        var response = await ClinicDoctorService.GetClinicDoctors();

        if (response.Code != ResultStatusEnum.Success)
        {
            ViewBag.Error = response.Message;
            return View(new List<ClinicDoctorDto>());
        }

        return View(response.Data ?? new List<ClinicDoctorDto>());
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        await LoadAvailableDoctors();

        return View(new ClinicDoctorDto
        {
            WorkingHours = new List<WorkingHourDto>
            {
                new()
            }
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(ClinicDoctorDto model)
    {
        if (!ModelState.IsValid)
        {
            await LoadAvailableDoctors();
            return View(model);
        }

        var response = await ClinicDoctorService.AddDoctorToClinic(model);

        if (response.Code != ResultStatusEnum.Success)
        {
            ModelState.AddModelError(string.Empty, response.Message);
            await LoadAvailableDoctors();
            return View(model);
        }

        TempData["Success"] = response.Message;

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var response = await ClinicDoctorService.GetClinicDoctor(id);

        if (response.Code != ResultStatusEnum.Success ||
            response.Data == null)
        {
            return NotFound();
        }

        return View(response.Data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        int id,
        ClinicDoctorDto model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var response = await ClinicDoctorService.UpdateClinicDoctorSchedule(id, model);

        if (response.Code != ResultStatusEnum.Success)
        {
            ModelState.AddModelError(string.Empty, response.Message);
            return View(model);
        }

        TempData["Success"] = response.Message;

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var response =
            await ClinicDoctorService.RemoveDoctorFromClinic(id);

        TempData[response.Code == ResultStatusEnum.Success ? "Success" : "Error"] = response.Message;

        return RedirectToAction(nameof(Index));
    }

    private async Task LoadAvailableDoctors()
    {
        var response = await ClinicDoctorService.GetAvailableDoctors();

        ViewBag.AvailableDoctors = response.Data ?? new List<DoctorResponseDto>();
    }
}