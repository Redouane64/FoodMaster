using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodMaster.WebSite.Data;

public static class ServiceCollectionExtensions
{
    public static void AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<FoodMasterDataContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("Default"))
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging();
        });
    }
}