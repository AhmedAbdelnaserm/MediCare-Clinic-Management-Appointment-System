using MediCare.Application.Identity.AppService;
using MediCare.Application.Identity.Localization;
using MediCare.IApplication.Identity.IAppService;
using MediCare.Common.Interface;
using MediCare.Presentation.Shared.Services;

namespace MediCare.Presentation.Web.Identity.Api.Configuration
{
    public static class IdentityResolveServices
    {
        public static IServiceCollection AddIdentityResolveServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IDoctorAccountService, DoctorAccountService>();
            services.AddScoped<ILocalizationService, LocalizationService>();

            return services;
        }
    }
}
