using MediCare.Application.BackEnd.AppService;
using MediCare.Application.BackEnd.Localization;
using MediCare.Application.Identity.AppService;
using MediCare.Common.Interface;
using MediCare.IApplication.BackEnd.IAppService;
using MediCare.IApplication.Identity.IAppService;
using MediCare.Presentation.Shared.Services;

namespace MediCare.Presentation.Web.Frontend.Mvc.Configuration;

public static class FrontendResolveServices
{
    public static IServiceCollection AddFrontendResolveServices(
        this IServiceCollection services)
    {
        services.AddScoped<ILocalizationService, LocalizationService>();
        services.AddScoped<ICityAppService, CityAppService>();
        services.AddScoped<IAreaAppService, AreaAppService>();
        services.AddScoped<IClinicAppService, ClinicAppService>();
        services.AddScoped<IClinicAdminAppService, ClinicAdminAppService>();

        services.AddAutoMapper(
            cfg => { },
            typeof(CityAppService).Assembly
        );

        services.AddHttpContextAccessor();
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        return services;
    }
}