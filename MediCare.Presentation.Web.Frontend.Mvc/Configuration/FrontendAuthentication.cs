namespace MediCare.Presentation.Web.Frontend.Mvc.Configuration;

public static class FrontendAuthentication
{
    public static IServiceCollection AddFrontendAuthentication(
        this IServiceCollection services,
        IWebHostEnvironment environment)
    {
        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/Account/Login";
            options.AccessDeniedPath = "/Account/AccessDenied";
            options.Cookie.HttpOnly = true;
            options.Cookie.SecurePolicy = environment.IsDevelopment()
                ? CookieSecurePolicy.SameAsRequest
                : CookieSecurePolicy.Always;
        });

        return services;
    }
}
