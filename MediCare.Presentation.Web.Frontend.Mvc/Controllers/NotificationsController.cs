using MediCare.Common.Enum;
using MediCare.IApplication.BackEnd.IAppService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediCare.Presentation.Web.Frontend.Mvc.Controllers;

[Authorize]
public sealed class NotificationsController : Controller
{
    private readonly IUserNotificationService _notifications;
    public NotificationsController(IUserNotificationService notifications) => _notifications = notifications;

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var result = await _notifications.GetMine();
        return View(result.Data ?? []);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> MarkAsRead(long id)
    {
        var result = await _notifications.MarkAsRead(id);
        TempData[result.Code == ResultStatusEnum.Success ? "Success" : "Error"] = result.Message;
        return RedirectToAction(nameof(Index));
    }
}
