using MediCare.Common.Enum;
using MediCare.Core.Entity.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediCare.Infrastructure.Repository.Seed;

public static class SuperAdminSeeder
{
    public static async Task SeedAsync(
        IServiceProvider serviceProvider,
        IConfiguration configuration)
    {
        var email = configuration["BootstrapSuperAdmin:Email"];
        var password = configuration["BootstrapSuperAdmin:Password"];
        var fullName = configuration["BootstrapSuperAdmin:FullName"];

        // Bootstrap is optional. Skip if credentials are not configured.
        if (string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(password) ||
            string.IsNullOrWhiteSpace(fullName))
        {
            return;
        }

        var userManager =
            serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        var roleName = UserRolesEnum.SuperAdmin.ToString();

        var user = await userManager.FindByEmailAsync(email);

        if (user is not null)
        {
            if (await userManager.IsInRoleAsync(user, roleName))
                return;

            throw new InvalidOperationException(
                $"The configured bootstrap email '{email}' already exists " +
                $"but is not assigned to the {roleName} role. " +
                "Review the account manually.");
        }

        user = new ApplicationUser
        {
            UserName = email,
            Email = email,
            EmailConfirmed = true,
            FullName = fullName
        };

        var createResult = await userManager.CreateAsync(user, password);

        if (!createResult.Succeeded)
        {
            var errors = string.Join(
                ", ",
                createResult.Errors.Select(e => e.Description));

            throw new InvalidOperationException(
                $"Failed to create SuperAdmin: {errors}");
        }

        var roleResult = await userManager.AddToRoleAsync(user, roleName);

        if (!roleResult.Succeeded)
        {
            var errors = string.Join(
                ", ",
                roleResult.Errors.Select(e => e.Description));

            // Roll back the newly created user if role assignment fails.
            await userManager.DeleteAsync(user);

            throw new InvalidOperationException(
                $"Failed to assign SuperAdmin role: {errors}");
        }
    }
}
