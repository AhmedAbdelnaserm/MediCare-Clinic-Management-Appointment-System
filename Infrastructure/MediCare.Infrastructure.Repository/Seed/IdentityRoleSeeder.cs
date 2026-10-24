using System.Linq;
using MediCare.Common.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace MediCare.Infrastructure.Repository.Seed;

public static class IdentityRoleSeeder
{
    public static async Task SeedAsync(
        IServiceProvider serviceProvider)
    {
        var roleManager =
            serviceProvider.GetRequiredService<
                RoleManager<IdentityRole>>();

        foreach (var role in Enum.GetNames<UserRolesEnum>())
        {
            if (await roleManager.RoleExistsAsync(role))
                continue;

            var result = await roleManager.CreateAsync(
                new IdentityRole(role));

            if (!result.Succeeded)
            {
                var errors = string.Join(
                    ", ",
                    result.Errors.Select(e => e.Description));

                throw new InvalidOperationException(
                    $"Failed to create role {role}: {errors}");
            }
        }
    }
}
