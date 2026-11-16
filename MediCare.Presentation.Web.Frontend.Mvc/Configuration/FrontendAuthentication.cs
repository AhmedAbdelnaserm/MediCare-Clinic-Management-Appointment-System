namespace MediCare.Presentation.Web.Frontend.Mvc.Configuration;

public static class FrontendAuthentication
{
    public static IServiceCollection AddFrontendAuthentication(
        this IServiceCollection services)
    {
        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/Account/Login";
            options.AccessDeniedPath = "/Account/AccessDenied";
            options.Cookie.HttpOnly = true;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        });

        return services;
    }
}