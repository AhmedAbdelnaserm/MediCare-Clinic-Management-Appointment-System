using MediCare.Core.Entity.Entity;
using MediCare.Infrastructure.Repository.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace MediCare.Presentation.Shared.Configuration
{
    public static class IdentityServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders(); // مهم للـ Password Reset / Email Confirmation

            return services;
        }
    }
}
