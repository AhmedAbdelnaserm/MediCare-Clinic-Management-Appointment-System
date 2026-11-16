using MediCare.Application.Identity.Dto.ClinicAdminDto;
using MediCare.Common.Dto;
using MediCare.Common.Enum;
using MediCare.IApplication.BackEnd.IAppService;
using MediCare.IApplication.Identity.IAppService;
using MediCare.Presentation.Web.Frontend.Mvc.Areas.SuperAdmin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediCare.Presentation.Web.Frontend.Mvc.Areas.SuperAdmin.Controllers;

[Area("SuperAdmin")]
[Authorize(Roles = nameof(UserRolesEnum.SuperAdmin))]
public class ClinicAdminsController : Controller
{
    private readonly IClinicAdminAppService ClinicAdminService;
    private readonly IClinicAppService ClinicService;

    public ClinicAdminsController(IClinicAdminAppService clinicAdminService, IClinicAppService clinicService)
    {
        ClinicAdminService = clinicAdminService;
        ClinicService = clinicService;
    }

    public async Task<IActionResult> Index()
    {
        var response = await ClinicAdminService.GetClinicAdmins();

        if (response.Code != ResultStatusEnum.Success)
        {
            ViewBag.Error = response.Message;
            return View(new List<ClinicAdminDto>());
        }

        return View(response.Data ?? new List<ClinicAdminDto>());
    }

    public async Task<IActionResult> Create()
    {
        await LoadClinics();
        return View(new ClinicAdminFormViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ClinicAdminFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            await LoadClinics();
            return View(model);
        }

        var request = new CreateClinicAdminRequestDto
        {
            FullName = model.FullName,
            Email = model.Email,
            Password = model.Password!,
            PhoneNumber = model.PhoneNumber,
            ClinicId = model.ClinicId
        };

        var response = await ClinicAdminService.CreateClinicAdmin(request);

        if (response.Code != ResultStatusEnum.Success)
        {
            ModelState.AddModelError(string.Empty, response.Message);
            await LoadClinics();
            return View(model);
        }

        TempData["Success"] = response.Message;
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(string id)
    {
        var response = await ClinicAdminService.GetClinicAdmin(id);

        if (response.Code != ResultStatusEnum.Success || response.Data == null)
            return NotFound();

        var admin = response.Data;

        var model = new ClinicAdminFormViewModel
        {
            FullName = admin.FullName,
            Email = admin.Email,
            PhoneNumber = admin.PhoneNumber,
            ClinicId = admin.ClinicId
        };

        ViewBag.UserId = id;
        await LoadClinics();

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, ClinicAdminFormViewModel model)
    {
        ModelState.Remove(nameof(model.Password));

        if (!ModelState.IsValid)
        {
            ViewBag.UserId = id;
            await LoadClinics();
            return View(model);
        }

        var request = new UpdateClinicAdminRequestDto
        {
            FullName = model.FullName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            ClinicId = model.ClinicId
        };

        var response = await ClinicAdminService.UpdateClinicAdmin(id, request);

        if (response.Code != ResultStatusEnum.Success)
        {
            ModelState.AddModelError(string.Empty, response.Message);
            ViewBag.UserId = id;
            await LoadClinics();
            return View(model);
        }

        TempData["Success"] = response.Message;
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(string id)
    {
        var response = await ClinicAdminService.GetClinicAdmin(id);

        if (response.Code != ResultStatusEnum.Success || response.Data == null)
            return NotFound();

        return View(response.Data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleStatus(string id, bool isActive)
    {
        var response = await ClinicAdminService.SetClinicAdminStatus(id, isActive);

        TempData[response.Code == ResultStatusEnum.Success ? "Success" : "Error"]
            = response.Message;

        return RedirectToAction(nameof(Index));
    }

    private async Task LoadClinics()
    {
        var response = await ClinicService.GetClinics();

        ViewBag.Clinics = response.Data ?? new List<TextValueBindingResponseDto>();
    }
}