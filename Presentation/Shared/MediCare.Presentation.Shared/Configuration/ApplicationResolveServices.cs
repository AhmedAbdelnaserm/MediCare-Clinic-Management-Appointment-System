using MediCare.Core.IRepository.IUnitOfWork;
using MediCare.Infrastructure.Repository.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace MediCare.Presentation.Shared.Configuration
{
    public static class ApplicationResolveServices
    {
        public static IServiceCollection AddApplicationResolveServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
