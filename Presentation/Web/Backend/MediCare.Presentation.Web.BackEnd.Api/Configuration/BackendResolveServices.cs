using MediCare.Application.BackEnd.AppService;
using MediCare.Application.BackEnd.Localization;
using MediCare.IApplication.BackEnd.IAppService;
using MediCare.Common.Interface;
using MediCare.Presentation.Shared.Services;

namespace MediCare.Presentation.Web.BackEnd.Api.Configuration
{
    public static class BackendResolveServices
    {
        public static IServiceCollection AddBackendResolveServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            // Add all services related to Backend
            services.AddScoped<ILocalizationService, LocalizationService>();
            services.AddScoped<ICityAppService, CityAppService>();
            services.AddScoped<IAreaAppService, AreaAppService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IClinicScheduleService, ClinicScheduleService>();
            services.AddScoped<IClinicalRecordService, ClinicalRecordService>();
            services.AddScoped<IClinicalAttachmentService, ClinicalAttachmentService>();
            services.AddScoped<IUserNotificationService, UserNotificationService>();
            services.AddScoped<IClinicAppService, ClinicAppService>();
            return services;
        }
    }
}
