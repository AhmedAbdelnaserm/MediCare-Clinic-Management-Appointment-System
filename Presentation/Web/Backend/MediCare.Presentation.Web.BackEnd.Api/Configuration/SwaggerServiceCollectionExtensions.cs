using Microsoft.OpenApi;

namespace MediCare.Presentation.Web.BackEnd.Api.Configuration
{
    public static class SwaggerServiceCollectionExtensions
    {
        public static IServiceCollection AddSwaggerWithJwt(
            this IServiceCollection services,
            string apiName)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = apiName,
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "MediCare Teams",
                        Email = "MediCare@gmail.com",
                        Url = new Uri("https://github.com/AhmedAbdelnaserm/MediCare-Clinic-Management-Appointment-System")
                    }
                });
                options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = "Add Your Token",
                    In = ParameterLocation.Header,
                });
                options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
                {
                    [new OpenApiSecuritySchemeReference("bearer", document)] = []
                });
            });
            return services;
        }
    }
}
