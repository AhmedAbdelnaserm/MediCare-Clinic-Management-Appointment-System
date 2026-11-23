using MediCare.Common.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediCare.Presentation.Web.Frontend.Mvc.Areas.Doctor.Controllers;

[Area("Doctor")]
[Authorize(Roles = nameof(UserRolesEnum.Doctor))]
public class DashboardController : Controller
{
    public IActionResult Index() { return View(); }
}
