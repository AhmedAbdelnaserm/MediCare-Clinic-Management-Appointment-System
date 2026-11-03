using MediCare.Application.BackEnd.AppService;
using MediCare.Application.BackEnd.Localization;
using MediCare.Application.Identity.AppService;
using MediCare.Application.Identity.Localization;
using MediCare.IApplication.BackEnd.IAppService;
using MediCare.IApplication.Identity.IAppService;
using Microsoft.AspNetCore.Identity;
using MediCare.Core.Entity.Entity;
using MediCare.Infrastructure.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace MediCare.Presentation.Web.BackEnd.Api.Configuration
{
    public static class BackendResolveServices
    {
        public static IServiceCollection AddBackendResolveServices(this IServiceCollection services)
        {
            // Add all services related to Backend
            services.AddScoped<global::MediCare.Application.BackEnd.Localization.ILocalizationService,
                global::MediCare.Application.BackEnd.Localization.LocalizationService>();
            services.AddScoped<ICityAppService, CityAppService>();
            services.AddScoped<IAreaAppService, AreaAppService>();
            services.AddScoped<ISpecializationAppService, SpecializationAppService>();
            services.AddScoped<IPatientAppService, PatientAppService>();

            // Authentication endpoints inside the Backend API (login/register) so that
            // users can obtain a JWT from the same service that validates it.
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<MediCare.Application.Identity.Localization.ILocalizationService,
                MediCare.Application.Identity.Localization.LocalizationService>();

            return services;
        }

        public static async Task SeedAsync(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                    await context.Database.MigrateAsync();
                    await DataSeeding.SeedAsync(context, userManager, roleManager);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating/seeding the database.");
                }
            }
        }
    }
}
