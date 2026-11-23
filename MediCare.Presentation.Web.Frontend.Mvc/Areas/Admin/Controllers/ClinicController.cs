using MediCare.Application.BackEnd.Dto.ClinicDto;
using MediCare.Common.Dto;
using AutoMapper;
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
    private readonly IMapper Mapper;

    public ClinicController(IClinicAppService clinicService, IAreaAppService areaService, ICityAppService cityService, IMapper mapper)
    {
        ClinicService = clinicService;
        AreaService = areaService;
        CityService = cityService;
        Mapper = mapper;
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

        var model = Mapper.Map<ClinicFormViewModel>(response.Data);

        await LoadFormData(model.CityId);

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ClinicFormViewModel model)
    {
        var response = await ClinicService.UpdateMyClinic(Mapper.Map<UpdateClinicRequestDto>(model));

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