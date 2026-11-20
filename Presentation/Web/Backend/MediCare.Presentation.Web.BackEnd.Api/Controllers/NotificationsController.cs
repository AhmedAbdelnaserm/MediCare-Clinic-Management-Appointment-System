using MediCare.Common.Enum;
using MediCare.IApplication.BackEnd.IAppService;
using MediCare.Presentation.Shared.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediCare.Presentation.Web.BackEnd.Api.Controllers;

[ApiController]
[Route("api/notifications")]
[Authorize]
public sealed class NotificationsController : ControllerBase
{
    private readonly IUserNotificationService _notifications;
    public NotificationsController(IUserNotificationService notifications) => _notifications = notifications;

    [HttpGet("mine")]
    public async Task<IActionResult> GetMine() => this.ToHttpResult(await _notifications.GetMine());

    [HttpPost("{id:long}/read")]
    public async Task<IActionResult> MarkAsRead(long id) => this.ToHttpResult(await _notifications.MarkAsRead(id));
}
