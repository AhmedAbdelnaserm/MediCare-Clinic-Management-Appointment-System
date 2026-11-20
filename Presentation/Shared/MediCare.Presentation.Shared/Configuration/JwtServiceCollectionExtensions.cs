using MediCare.Common.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MediCare.Presentation.Shared.Configuration
{
    public static class JwtServiceCollectionExtensions
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JWT");
            var signingKey = jwtSettings["Key"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];
            var expiryInMinutes = jwtSettings.GetValue<int?>("ExpiryInMinutes");

            if (string.IsNullOrWhiteSpace(signingKey) ||
                Encoding.UTF8.GetByteCount(signingKey) < 32 ||
                string.IsNullOrWhiteSpace(issuer) ||
                string.IsNullOrWhiteSpace(audience) ||
                expiryInMinutes is null or <= 0)
            {
                throw new InvalidOperationException(
                    "JWT:Key (at least 32 bytes), JWT:Issuer, JWT:Audience, and a positive JWT:ExpiryInMinutes must be configured.");
            }

            services.Configure<JWT>(jwtSettings);
            var key = Encoding.UTF8.GetBytes(signingKey);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    RoleClaimType = "roles",
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ClockSkew = TimeSpan.Zero
                };

            });

            return services;
        }
    }
}
