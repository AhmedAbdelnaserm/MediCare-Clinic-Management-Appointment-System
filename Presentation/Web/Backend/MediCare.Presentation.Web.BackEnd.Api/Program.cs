using MediCare.Application.BackEnd.Mapping;
using MediCare.Presentation.Shared.Configuration;
using MediCare.Presentation.Web.BackEnd.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(
    cfg => { },
    typeof(AreaMapping).Assembly
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
