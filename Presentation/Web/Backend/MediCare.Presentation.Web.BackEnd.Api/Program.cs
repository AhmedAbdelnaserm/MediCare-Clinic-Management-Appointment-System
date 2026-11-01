var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddAutoMapper(
//    cfg => { },
//    typeof(ResturantMapping).Assembly
//);
// ===== Add Services =====
//builder.Services
//    .AddDbServices(builder.Configuration)
//    .AddCorsWithDefaultPolicy()
//    .AddIdentityServices()
//    .AddBackendResolveServices()
//    .AddJwtAuthentication(builder.Configuration)
//    .AddApplicationResolveServices()
//    .AddSwaggerWithJwt("Backend API");


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
