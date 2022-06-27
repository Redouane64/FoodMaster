using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using FoodMaster.WebSite.Data;
using FoodMaster.WebSite.Domain.Customers;
using FoodMaster.WebSite.Infrastructure.Identity;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FoodMaster.WebSite.Infrastructure;

public static class ApplicationExtensions
{
    public static async Task InitializeDefaultRoles(this IHost host)
    {
        var logger = host.Services.GetService<ILogger<IHost>>();

        using var scope = host.Services.CreateScope();
        using var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        await using var context = scope.ServiceProvider.GetRequiredService<FoodMasterDataContext>();
        await using var transaction = await context.Database.BeginTransactionAsync();
        var configuration = scope.ServiceProvider.GetService<IConfiguration>();

        try
        {
            var roles = configuration.GetSection("DefaultSettings:DefaultRoles").Get<string[]>();
            foreach (var role in roles.Select(r => new IdentityRole(FoodMasterDefaultRoles.Administrator)
            {
                NormalizedName = FoodMasterDefaultRoles.Administrator.ToUpperInvariant()
            }))
            {
                var createRoleResult = await roleManager.CreateAsync(role);
                if (!createRoleResult.Succeeded)
                {
                    logger.LogWarning("Unable to create role {role}", role);
                    continue;
                }

                _ = await roleManager.AddClaimAsync(role, new Claim("role", FoodMasterDefaultRoles.Administrator));
            }

            await transaction.CommitAsync();
        }
        catch (Exception e)
        {
            logger.LogError(e, "Unable to create default roles");
            await transaction.RollbackAsync();
        }
    }

    public static async Task InitializeDefaultUser(this IHost host)
    {
        var logger = host.Services.GetService<ILogger<IHost>>();

        using var scope = host.Services.CreateScope();
        using var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
        using var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        await using var context = scope.ServiceProvider.GetRequiredService<FoodMasterDataContext>();
        await using var transaction = await context.Database.BeginTransactionAsync();
        var configuration = scope.ServiceProvider.GetService<IConfiguration>();
        try
        {
            var user = new User()
            {
                Email = configuration.GetValue<string>("DefaultSettings:DefaultUser:Email"),
                UserName = configuration.GetValue<string>("DefaultSettings:DefaultUser:UserName"),
                FullName = configuration.GetValue<string>("DefaultSettings:DefaultUser:Password"),
            };

            var createUserResult = await userManager.CreateAsync(user, "admin1");
            if (!createUserResult.Succeeded)
            {
                await transaction.RollbackAsync();
                return;
            }

            var setRoleResult = await userManager.AddToRoleAsync(user, FoodMasterDefaultRoles.Administrator);
            if (!setRoleResult.Succeeded)
            {
                await transaction.RollbackAsync();
                return;
            }

            await transaction.CommitAsync();
        }
        catch (Exception e)
        {
            logger.LogError(e, "Unable to create default user");
            await transaction.RollbackAsync();
        }

    }
}