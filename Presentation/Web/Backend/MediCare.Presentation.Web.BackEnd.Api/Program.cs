using MediCare.Infrastructure.Repository;
using MediCare.Presentation.Shared.Configuration;
using MediCare.Presentation.Web.BackEnd.Api.Configuration;
using MediCare.Presentation.Web.BackEnd.Api.Services;

var builder = WebApplication.CreateBuilder(args);

//===== Add Services =====
builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddCorsWithDefaultPolicy(builder.Configuration)
    .AddBackendResolveServices()
    .AddJwtAuthentication(builder.Configuration)
    .AddSwaggerWithJwt("Backend API");


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHostedService<AppointmentReminderWorker>();

var app = builder.Build();

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
