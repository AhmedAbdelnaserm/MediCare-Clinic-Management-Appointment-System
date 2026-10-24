using MediCare.Presentation.Web.Identity.Api.Configuration;
using MediCare.Presentation.Shared.Configuration;
using MediCare.Infrastructure.Repository.Seed;
using MediCare.Application.Identity.Mapping;

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

var app = builder.Build();

// ===== Seed Identity Roles =====
// فعّل الكود ده بعد إنشاء الـ Database والجداول بنجاح

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
