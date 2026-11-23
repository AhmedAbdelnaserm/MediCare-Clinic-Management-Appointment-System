using MediCare.Application.BackEnd.Dto.DoctorDto;
using MediCare.Common.Enum;
using MediCare.IApplication.BackEnd.IAppService;
using MediCare.Presentation.Web.Frontend.Mvc.Areas.Doctor.ViewModels.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediCare.Presentation.Web.Frontend.Mvc.Areas.Doctor.Controllers;

[Area("Doctor")]
[Authorize(Roles = nameof(UserRolesEnum.Doctor))]
[Route("Doctor/Profile")]
public class DoctorProfileController : Controller
{
    private readonly IDoctorPortalService _doctorPortalService;

    public DoctorProfileController(IDoctorPortalService doctorPortalService)
    {
        _doctorPortalService = doctorPortalService;
    }

    [HttpPost("Save")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Save(DoctorFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            TempData["ProfileError"] = "Please complete the required profile fields and try again.";
            return RedirectToAction("Index", "Dashboard");
        }

        await using var imageStream = model.ProfileImageFile?.OpenReadStream();
        var response = await _doctorPortalService.UpdateMyProfile(
            new UpdateDoctorProfileRequestDto
            {
                SpecializationId = model.SpecializationId,
                DoctorDegree = model.DoctorDegree,
                EnDescription = model.EnDescription
            },
            imageStream,
            model.ProfileImageFile?.FileName,
            model.ProfileImageFile?.Length ?? 0);

        if (response.Code != ResultStatusEnum.Success || response.Data == null)
        {
            TempData["ProfileError"] = response.Message;
            return RedirectToAction("Index", "Dashboard");
        }

        TempData["ProfileSuccess"] = response.Message;
        return RedirectToAction("Index", "Dashboard");
    }
}