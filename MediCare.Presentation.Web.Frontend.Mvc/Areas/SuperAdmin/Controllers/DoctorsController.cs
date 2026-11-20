using MediCare.Application.Identity.Dto.DoctorDto;
using MediCare.Common.Enum;
using MediCare.IApplication.BackEnd.IAppService;
using MediCare.IApplication.Identity.IAppService;
using MediCare.Presentation.Web.Frontend.Mvc.Areas.SuperAdmin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;

namespace MediCare.Presentation.Web.Frontend.Mvc.Areas.SuperAdmin.Controllers;

[Area("SuperAdmin")]
[Authorize(Roles = nameof(UserRolesEnum.SuperAdmin))]
public sealed class DoctorsController : Controller
{
    private readonly IDoctorService _doctorService;
    private readonly IDoctorAccountService _doctorAccountService;

    public DoctorsController(IDoctorService doctorService, IDoctorAccountService doctorAccountService)
    {
        _doctorService = doctorService;
        _doctorAccountService = doctorAccountService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var response = await _doctorService.GetDoctors();
        if (response.Code != MediCare.Common.Enum.ResultStatusEnum.Success)
        {
            ViewBag.Error = response.Message;
            return View(new List<MediCare.Application.BackEnd.Dto.DoctorDto.DoctorResponseDto>());
        }

        return View(response.Data ?? []);
    }

    [HttpGet]
    public IActionResult Create()
    {
        LoadSpecializations();
        return View(new DoctorAccountFormViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(DoctorAccountFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            LoadSpecializations();
            return View(model);
        }

        var response = await _doctorAccountService.Create(new CreateDoctorAccountRequestDto
        {
            FullName = model.FullName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            Password = model.Password,
            SpecializationId = model.SpecializationId,
            ConsultationFee = model.ConsultationFee,
            EnName = model.EnName,
            EnDescription = model.EnDescription,
            DoctorDegree = model.DoctorDegree
        });

        if (response.Code != MediCare.Common.Enum.ResultStatusEnum.Success || response.Data is null)
        {
            ModelState.AddModelError(string.Empty, response.Message);
            LoadSpecializations();
            return View(model);
        }

        TempData["Success"] = $"Doctor {response.Data.FullName} created. Assign the doctor to a clinic to configure availability.";
        return RedirectToAction("Index", "Schedules");
    }

    private void LoadSpecializations()
    {
        ViewBag.Specializations = Enum.GetValues<SpecializationEnum>()
            .Select(value => new SelectListItem(
                Regex.Replace(value.ToString(), "(?<!^)([A-Z])", " $1"),
                ((int)value).ToString()))
            .ToList();
    }
}
