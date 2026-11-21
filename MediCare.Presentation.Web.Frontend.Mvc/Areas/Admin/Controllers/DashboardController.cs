using MediCare.Common.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediCare.Presentation.Web.Frontend.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(UserRolesEnum.ClinicAdmin))]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
