using MediCare.Common.ExtensionMethod;
using MediCare.Common.Interface;
using Microsoft.AspNetCore.Http;

namespace MediCare.Presentation.Shared.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? UserId =>
        _httpContextAccessor.HttpContext?.User.GetUserId();
}