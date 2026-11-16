
using MediCare.Common.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediCare.Presentation.Web.Frontend.Mvc.Areas.SuperAdmin.Controllers;

[Area("SuperAdmin")]
[Authorize(Roles = nameof(UserRolesEnum.SuperAdmin))]
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
