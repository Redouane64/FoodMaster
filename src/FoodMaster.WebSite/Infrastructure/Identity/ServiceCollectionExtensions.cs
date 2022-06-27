using FoodMaster.WebSite.Data;
using FoodMaster.WebSite.Domain.Customers;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodMaster.WebSite.Infrastructure.Identity;

public static class ServiceCollectionExtensions
{
    public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.Name = "FoodMaster";
        });

        services.ConfigureExternalCookie(options =>
        {
            options.Cookie.Name = "FoodMaster.External";
        });

        services.AddAuthentication();

        services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

                options.Lockout.AllowedForNewUsers = false;

                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;

            })
            .AddEntityFrameworkStores<FoodMasterDataContext>()
            .AddTokenProvider<UserTokenProvider>(UserTokenProvider.ProviderName);
    }
}