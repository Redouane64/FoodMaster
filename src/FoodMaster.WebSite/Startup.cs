using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

using AutoMapper;

using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.Data;
using FoodMaster.WebSite.Domain;
using FoodMaster.WebSite.Filters;
using FoodMaster.WebSite.Infrastructure.Services;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FoodMaster.WebSite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddControllers();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options => {
                        options.LoginPath = "/Account/GuestLogin";
                        options.LogoutPath = "/Account/GuestLogin?handler=SignOut";
                        options.ClaimsIssuer = "FoodMaster";
                        options.Cookie.MaxAge = TimeSpan.FromDays(5);
                        options.Cookie.IsEssential = true;
                        options.Cookie.Name = "FoodMaster";
                        options.EventsType = typeof(CookieValidatorEvents);
                    });
            services.AddScoped<CookieValidatorEvents>();

            services.AddAutoMapper(this.GetType().Assembly);
            
            services.AddSingleton<JsonDataContext>(_ => JsonDataContext.Create());
            services.AddSingleton(s => s.GetRequiredService<JsonDataContext>().Meals);
            services.AddSingleton(s => s.GetRequiredService<JsonDataContext>().Ingredients);
            services.AddSingleton(s => s.GetRequiredService<JsonDataContext>().Users);
            services.AddSingleton(s => s.GetRequiredService<JsonDataContext>().Orders);
            services.AddSingleton(s => s.GetRequiredService<JsonDataContext>().Categories);

            services.AddScoped<IStockService, StockService>();
            services.AddScoped<IMealsService, MealsService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IOrdersService, OrdersService>();

            services.AddHttpContextAccessor();
            services.AddScoped<ICartService>(s =>
            {
                var carts = s.GetRequiredService<JsonDataContext>().Carts;
                var httpContextAccessor = s.GetRequiredService<IHttpContextAccessor>();
                var userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                var userCart = carts.FirstOrDefault(cart => cart.UserId == userId);

                if (userCart == null)
                {
                    userCart = new Cart { UserId = userId, Items = new List<CartItem>() };
                    carts.Add(userCart);
                }

                var mealService = s.GetRequiredService<IMealsService>();
                return new CartService(userCart.Items, mealService);
            });

            services.AddSingleton<WriteToDiskFilterAttribute>();
            services.AddSingleton<IDiscountProvider, BirthdayDiscountProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
