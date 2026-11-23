
using MediCare.Application.BackEnd.Dto.ClinicDto;
using AutoMapper;
using MediCare.Common.Dto;
using MediCare.Common.Enum;
using MediCare.IApplication.BackEnd.IAppService;
using MediCare.Presentation.Web.Frontend.Mvc.Areas.SuperAdmin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediCare.Presentation.Web.Frontend.Mvc.Areas.SuperAdmin.Controllers;

[Area("SuperAdmin")]
[Authorize(Roles = nameof(UserRolesEnum.SuperAdmin))]
public class ClinicsController : Controller
{
    private readonly IClinicAppService ClinicService;
    private readonly IAreaAppService AreaService;
    private readonly ICityAppService CityService;
    private readonly IMapper Mapper;

    public ClinicsController(IClinicAppService clinicService, IAreaAppService areaService, ICityAppService cityService, IMapper mapper)
    {
        ClinicService = clinicService;
        AreaService = areaService;
        CityService = cityService;
        Mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var response = await ClinicService.GetClinicsForManagement();

        if (response.Code != ResultStatusEnum.Success)
        {
            ViewBag.Error = response.Message;
            return View(new List<ClinicDto>());
        }

        return View(response.Data);
    }

    public async Task<IActionResult> Create()
    {
        await LoadFormData();

        return View(new ClinicFormViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ClinicFormViewModel model)
    {
        var response = await ClinicService.CreateClinic(Mapper.Map<CreateClinicRequestDto>(model));

        if (response.Code != ResultStatusEnum.Success)
        {
            ModelState.AddModelError(string.Empty, response.Message);
            await LoadFormData(model.CityId);
            return View(model);
        }

        TempData["Success"] = response.Message;
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var response = await ClinicService.GetClinic(id);

        if (response.Code != ResultStatusEnum.Success || response.Data == null)
            return NotFound();

        var model = Mapper.Map<ClinicFormViewModel>(response.Data);

        ViewBag.ClinicId = id;

        await LoadFormData(model.CityId);

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ClinicFormViewModel model)
    {
        var response = await ClinicService.UpdateClinic(id, Mapper.Map<UpdateClinicRequestDto>(model));

        if (response.Code != ResultStatusEnum.Success)
        {
            ModelState.AddModelError(string.Empty, response.Message);
            ViewBag.ClinicId = id;
            await LoadFormData(model.CityId);
            return View(model);
        }

        TempData["Success"] = response.Message;
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int id)
    {
        var response = await ClinicService.GetClinic(id);

        if (response.Code != ResultStatusEnum.Success || response.Data == null)
            return NotFound();

        return View(response.Data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await ClinicService.DeleteClinic(id);

        TempData[response.Code == ResultStatusEnum.Success ? "Success" : "Error"]
            = response.Message;

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> GetAreasByCity(int cityId)
    {
        var response = await AreaService.GetAreasByCityId(cityId);

        return Json(
            response.Code == ResultStatusEnum.Success
                ? response.Data
                : new List<TextValueBindingResponseDto>());
    }

    private async Task LoadFormData(int? cityId = null)
    {
        var citiesResponse = await CityService.GetCities();

        ViewBag.Cities = citiesResponse.Data
            ?? new List<TextValueBindingResponseDto>();

        if (cityId.HasValue && cityId.Value > 0)
        {
            var areasResponse = await AreaService.GetAreasByCityId(cityId.Value);

            ViewBag.Areas = areasResponse.Data
                ?? new List<TextValueBindingResponseDto>();
        }
        else
        {
            ViewBag.Areas = new List<TextValueBindingResponseDto>();
        }
    }
}
