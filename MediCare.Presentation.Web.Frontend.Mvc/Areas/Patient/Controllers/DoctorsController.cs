using MediCare.Application.BackEnd.Dto.DoctorDto;
using MediCare.Common.Enum;
using MediCare.IApplication.BackEnd.IAppService;
using MediCare.Presentation.Web.Frontend.Mvc.Areas.Patient.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace MediCare.Presentation.Web.Frontend.Mvc.Areas.Patient.Controllers;

[Area("Patient")]
[Authorize(Roles = nameof(UserRolesEnum.Patient))]
public sealed class DoctorsController : Controller
{
    private readonly IDoctorService _doctorService;

    public DoctorsController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    public async Task<IActionResult> Index(int? specializationId)
    {
        var response = specializationId is > 0
            ? await _doctorService.GetDoctorsBySpecializationId(specializationId.Value)
            : await _doctorService.GetDoctors();

        var specializations = Enum.GetValues<SpecializationEnum>()
            .Select(specialization => new SelectListItem(
                Regex.Replace(specialization.ToString(), "(?<!^)([A-Z])", " $1"),
                ((int)specialization).ToString(),
                specializationId == (int)specialization))
            .ToList();

        if (response.Code != ResultStatusEnum.Success)
        {
            ViewBag.Error = response.Message;
            return View(new DoctorDirectoryViewModel
            {
                SpecializationId = specializationId,
                Specializations = specializations
            });
        }

        return View(new DoctorDirectoryViewModel
        {
            SpecializationId = specializationId,
            Specializations = specializations,
            Doctors = response.Data ?? new List<DoctorResponseDto>()
        });
    }
}
