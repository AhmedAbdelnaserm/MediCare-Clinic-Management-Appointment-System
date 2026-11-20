using MediCare.Common.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediCare.Presentation.Web.Frontend.Mvc.Areas.Patient.Controllers;

[Area("Patient")]
[Authorize(Roles = nameof(UserRolesEnum.Patient))]
public sealed class DashboardController : Controller
{
    public IActionResult Index() => View();
}
