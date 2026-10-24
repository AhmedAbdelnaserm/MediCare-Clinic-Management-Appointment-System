using Microsoft.Extensions.DependencyInjection;

namespace MediCare.Presentation.Shared.Configuration
{
    public static class CorsServiceCollectionExtensions
    {
        public static IServiceCollection AddCorsWithDefaultPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            return services;
        }
    }
}
