using MediCare.Application.BackEnd.AppService;
using MediCare.Application.BackEnd.Mapping;
using MediCare.Core.IRepository.IRepository;
using MediCare.IApplication.BackEnd.IAppService;
using MediCare.Infrastructure.Repository.Repository;
using MediCare.Presentation.Shared.Configuration;
using MediCare.Presentation.Web.BackEnd.Api.Configuration;
using MediCare.Core.Entity.Entity;
using MediCare.Infrastructure.Repository.Context;
using MediCare.Infrastructure.Repository.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(
    cfg => { },
    typeof(AreaMapping).Assembly,
    typeof(MediCare.Application.Identity.Mapping.ApplicationUserMapping).Assembly
);

//===== Add Services =====
builder.Services
    .AddDbServices(builder.Configuration)
    .AddCorsWithDefaultPolicy()
    .AddIdentityServices()
    .AddBackendResolveServices()
    .AddJwtAuthentication(builder.Configuration)
    .AddApplicationResolveServices()
    .AddSwaggerWithJwt("Backend API");


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// 1. Register the Generic Repository
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// 2. Register the Specialization App Service
builder.Services.AddScoped<ISpecializationAppService, SpecializationAppService>();

// 3. Register the Patient Repository
builder.Services.AddScoped<IPatientRepository, PatientRepository>();

var app = builder.Build();

// ====== DATABASE MIGRATION & SEED DATA EXECUTION ======
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

        // Run the async seeder (roles, users, patient, doctor, clinic, appointment...)
        await DataSeeding.SeedAsync(context, userManager, roleManager);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating/seeding the database.");
    }
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