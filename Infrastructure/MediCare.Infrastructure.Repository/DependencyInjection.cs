using MediCare.Core.Entity.Entity;
using MediCare.Core.IRepository.IUnitOfWork;
using MediCare.Infrastructure.Repository.Context;
using MediCare.Infrastructure.Repository.UnitOfWork;
using MediCare.Infrastructure.Repository.Storage;
using MediCare.Application.BackEnd.Storage;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediCare.Infrastructure.Repository;

/// <summary>Registers persistence and identity adapters at the application composition root.</summary>
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException(
                "Connection string 'DefaultConnection' is not configured.");
        }

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<IUnitOfWork, MediCare.Infrastructure.Repository.UnitOfWork.UnitOfWork>();
        services.AddSingleton<IPrivateAttachmentStorage, PrivateAttachmentStorage>();
        return services;
    }
}
