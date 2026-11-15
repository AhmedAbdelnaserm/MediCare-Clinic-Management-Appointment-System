using MediCare.Core.IRepository.IUnitOfWork;
using MediCare.Infrastructure.Repository.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace MediCare.Presentation.Shared.Configuration
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
