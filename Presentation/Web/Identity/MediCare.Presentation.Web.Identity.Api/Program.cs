using MediCare.Application.BackEnd.AppService;
using MediCare.Application.Identity.Mapping;
using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IRepository;
using MediCare.IApplication.BackEnd.IAppService;
using MediCare.Infrastructure.Repository.Context;
using MediCare.Infrastructure.Repository.Repository;
using MediCare.Infrastructure.Repository.Seed;
using MediCare.Presentation.Shared.Configuration;
using MediCare.Presentation.Web.Identity.Api.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAutoMapper(
    cfg => { },
    typeof(ApplicationUserMapping).Assembly
);



// ===== Cross-Cutting Configurations =====
builder.Services
    .AddDbServices(builder.Configuration)
    .AddCorsWithDefaultPolicy()
    .AddIdentityResolveServices()
    .AddIdentityServices()
    .AddJwtAuthentication(builder.Configuration)
    .AddSwaggerWithJwt("Identity API")
    .AddApplicationResolveServices();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// AppService registration
builder.Services.AddScoped<ISpecializationAppService, SpecializationAppService>();


var app = builder.Build();

// ===== Seed Identity Roles =====
// فعّل الكود ده بعد إنشاء الـ Database والجداول بنجاح
// ====== SEED DATA EXECUTION ======
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        // Apply any pending migrations automatically on startup
        await context.Database.MigrateAsync();

        // Run the async seeder
        await DataSeeding.SeedAsync(context, userManager, roleManager);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

using (var scope = app.Services.CreateScope())
{
    await IdentityRoleSeeder.SeedAsync(scope.ServiceProvider);
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(); // CORS قبل Authentication/Authorization

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
