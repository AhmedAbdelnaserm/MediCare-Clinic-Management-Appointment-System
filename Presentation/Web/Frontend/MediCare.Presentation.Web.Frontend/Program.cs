using System.Net.Http;

namespace MediCare.Presentation.Web.Frontend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add MVC Controllers with Views
            builder.Services.AddControllersWithViews();

            // Configure HttpClient to talk to MediCare.Presentation.Web.BackEnd.Api on port 7246
            builder.Services.AddHttpClient("BackendApi", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7246/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            })
            .ConfigurePrimaryHttpMessageHandler(() =>
            {
                var handler = new HttpClientHandler();
                // Bypass SSL certificate check for local development
                if (builder.Environment.IsDevelopment())
                {
                    handler.ServerCertificateCustomValidationCallback =
                        HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                }
                return handler;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Default route mapping
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Specialization}/{action=Index}/{id?}");

            app.Run();
        }
    }
}