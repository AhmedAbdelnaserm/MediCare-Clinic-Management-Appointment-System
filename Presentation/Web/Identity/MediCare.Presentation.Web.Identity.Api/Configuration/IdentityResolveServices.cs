using MediCare.Application.Identity.AppService;
using MediCare.Application.Identity.Localization;
using MediCare.IApplication.Identity.IAppService;

namespace MediCare.Presentation.Web.Identity.Api.Configuration
{
    public static class IdentityResolveServices
    {
        public static IServiceCollection AddIdentityResolveServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ILocalizationService, LocalizationService>();

            return services;
        }
    }
}
