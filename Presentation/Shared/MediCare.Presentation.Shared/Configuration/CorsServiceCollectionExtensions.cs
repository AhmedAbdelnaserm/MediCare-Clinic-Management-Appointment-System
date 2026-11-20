using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediCare.Presentation.Shared.Configuration;

public static class CorsServiceCollectionExtensions
{
    public static IServiceCollection AddCorsWithDefaultPolicy(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var allowedOrigins = configuration
            .GetSection("Cors:AllowedOrigins")
            .Get<string[]>() ?? [];

        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                if (allowedOrigins.Length > 0)
                    policy.WithOrigins(allowedOrigins);

                policy.AllowAnyMethod().AllowAnyHeader();
            });
        });

        return services;
    }
}
