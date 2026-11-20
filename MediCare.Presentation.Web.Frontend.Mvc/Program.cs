using MediCare.Infrastructure.Repository;
using MediCare.Presentation.Shared.Configuration;
using MediCare.Presentation.Web.Frontend.Mvc.Configuration;
using MediCare.Common.Helper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddFrontendResolveServices()
    .AddFrontendAuthentication(builder.Environment);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
