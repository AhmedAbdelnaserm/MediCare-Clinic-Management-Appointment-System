using MediCare.Application.BackEnd.AppService;
using MediCare.Application.BackEnd.Localization;
using MediCare.Application.Identity.AppService;
using MediCare.Common.Interface;
using MediCare.Application.Identity.Localization;
using MediCare.IApplication.BackEnd.IAppService;
using MediCare.Presentation.Web.Frontend.Mvc.Services;
using MediCare.IApplication.Identity.IAppService;
using MediCare.Presentation.Shared.Services;
using MediCare.Presentation.Web.Frontend.Mvc.Areas.Doctor.Mapping;

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
        services.AddScoped<IClinicDoctorAppService, ClinicDoctorAppService>();
        services.AddScoped<IDoctorPortalService, DoctorPortalService>();
        services.AddScoped<IProfileImageStorage, WebRootProfileImageStorage>();

        services.AddAutoMapper(
            cfg => { },
            typeof(CityAppService).Assembly,
            typeof(DoctorProfileViewMapping).Assembly,
            typeof(FrontendResolveServices).Assembly
        );
        services.AddScoped<ILocalizationService,LocalizationService>();
        services.AddHttpContextAccessor();
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        return services;
    }
}