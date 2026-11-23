using MediCare.Application.BackEnd.Dto.DoctorDto;
using MediCare.Common.Enum;
using MediCare.IApplication.BackEnd.IAppService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediCare.Presentation.Web.Frontend.Mvc.Areas.Doctor.Controllers;

[Area("Doctor")]
[Authorize(Roles = nameof(UserRolesEnum.Doctor))]
public class DoctorClinicController : Controller
{
    private readonly IDoctorPortalService _doctorPortalService;
    public DoctorClinicController(IDoctorPortalService doctorPortalService)
    {
        _doctorPortalService = doctorPortalService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var response = await _doctorPortalService.GetMyClinics();
        if (response.Code != ResultStatusEnum.Success || response.Data == null)
        {
            ViewBag.Error = response.Message;
            return View(new List<DoctorClinicSummaryDto>());
        }

        return View(response.Data);
    }
}
