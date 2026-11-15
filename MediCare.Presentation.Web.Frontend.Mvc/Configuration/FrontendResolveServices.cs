using MediCare.Application.BackEnd.AppService;
using MediCare.Application.BackEnd.Localization;
using MediCare.IApplication.BackEnd.IAppService;

namespace MediCare.Presentation.Web.Frontend.Mvc.Configuration;

public static class FrontendResolveServices
{
    public static IServiceCollection AddFrontendResolveServices(
        this IServiceCollection services)
    {
        services.AddScoped<ILocalizationService, LocalizationService>();
        services.AddScoped<ICityAppService, CityAppService>();
        services.AddScoped<IAreaAppService, AreaAppService>();

        services.AddAutoMapper(
            cfg => { },
            typeof(CityAppService).Assembly
        );

        return services;
    }
}