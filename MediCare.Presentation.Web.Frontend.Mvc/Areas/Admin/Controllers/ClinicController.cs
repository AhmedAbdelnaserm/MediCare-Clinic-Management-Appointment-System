using MediCare.Application.BackEnd.Dto.ClinicDto;
using MediCare.Common.Dto;
using MediCare.Common.Enum;
using MediCare.IApplication.BackEnd.IAppService;
using MediCare.Presentation.Web.Frontend.Mvc.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediCare.Presentation.Web.Frontend.Mvc.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = nameof(UserRolesEnum.ClinicAdmin))]
public class ClinicController : Controller
{
    private readonly IClinicAppService ClinicService;
    private readonly IAreaAppService AreaService;
    private readonly ICityAppService CityService;

    public ClinicController(IClinicAppService clinicService, IAreaAppService areaService, ICityAppService cityService)
    {
        ClinicService = clinicService;
        AreaService = areaService;
        CityService = cityService;
    }

    public async Task<IActionResult> Index()
    {
        var response = await ClinicService.GetMyClinic();

        if (response.Code != ResultStatusEnum.Success || response.Data == null)
        {
            ViewBag.Error = response.Message;
            return View();
        }

        return View(response.Data);
    }

    public async Task<IActionResult> Edit()
    {
        var response = await ClinicService.GetMyClinic();

        if (response.Code != ResultStatusEnum.Success || response.Data == null)
            return NotFound();

        var clinic = response.Data;

        var model = new ClinicFormViewModel
        {
            EnName = clinic.EnName,
            EnDescription = clinic.EnDescription,
            Address = clinic.Address,
            PhoneNumber = clinic.PhoneNumber,
            CityId = clinic.CityId,
            AreaId = clinic.AreaId
        };

        await LoadFormData(model.CityId);

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ClinicFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            await LoadFormData(model.CityId);
            return View(model);
        }

        var request = new UpdateClinicRequestDto
        {
            EnName = model.EnName,
            EnDescription = model.EnDescription,
            Address = model.Address,
            PhoneNumber = model.PhoneNumber,
            AreaId = model.AreaId
        };

        var response = await ClinicService.UpdateMyClinic(request);

        if (response.Code != ResultStatusEnum.Success)
        {
            ModelState.AddModelError(string.Empty, response.Message);

            await LoadFormData(model.CityId);
            return View(model);
        }

        TempData["Success"] = response.Message;

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> GetAreasByCity(int cityId)
    {
        if (cityId <= default(int))
            return Json(new List<TextValueBindingResponseDto>());

        var response = await AreaService.GetAreasByCityId(cityId);

        return Json(response.Code == ResultStatusEnum.Success ? response.Data : new List<TextValueBindingResponseDto>());
    }

    private async Task LoadFormData(int? cityId = null)
    {
        var citiesResponse = await CityService.GetCities();

        ViewBag.Cities = citiesResponse.Data ?? new List<TextValueBindingResponseDto>();

        if (cityId.HasValue && cityId.Value > default(int))
        {
            var areasResponse = await AreaService.GetAreasByCityId(cityId.Value);

            ViewBag.Areas = areasResponse.Data ?? new List<TextValueBindingResponseDto>();
        }
        else
        {
            ViewBag.Areas = new List<TextValueBindingResponseDto>();
        }
    }
}