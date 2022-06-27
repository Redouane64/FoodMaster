using System.Threading.Tasks;

using FoodMaster.WebSite.Infrastructure;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace FoodMaster.WebSite
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var app = CreateHostBuilder(args).Build();

            await app.InitializeDefaultRoles();
            await app.InitializeDefaultUser();

            await app.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
