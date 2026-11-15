using MediCare.Application.BackEnd.AppService;
using MediCare.Application.BackEnd.Localization;
using MediCare.IApplication.BackEnd.IAppService;

namespace MediCare.Presentation.Web.BackEnd.Api.Configuration
{
    public static class BackendResolveServices
    {
        public static IServiceCollection AddBackendResolveServices(this IServiceCollection services)
        {
            // Add all services related to Backend
            services.AddScoped<ILocalizationService, LocalizationService>();
            services.AddScoped<ICityAppService, CityAppService>();
            services.AddScoped<IAreaAppService, AreaAppService>();
            services.AddScoped<IClinicAppService, ClinicAppService>();
            return services;
        }
    }
}
