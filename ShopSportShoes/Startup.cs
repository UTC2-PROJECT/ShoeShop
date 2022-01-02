using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopSportShoes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using ShopSportShoes.Models.Identity;
using Microsoft.AspNetCore.Identity;
using ShopSportShoes.Repositories.Interfaces;
using ShopSportShoes.Repositories;
using ShopSportShoes.Models;
using MudBlazor.Services;
using ShopSportShoes.Services;
using MudBlazor;

namespace ShopSportShoes
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddMemoryCache();

            services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopCenter;
                config.SnackbarConfiguration.PreventDuplicates = false;
                config.SnackbarConfiguration.NewestOnTop = true;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.VisibleStateDuration = 3000;
                config.SnackbarConfiguration.HideTransitionDuration = 500;
                config.SnackbarConfiguration.ShowTransitionDuration = 500;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
            });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.Name = ".AdventureWorks.Session";
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // Set 
            services.AddDbContextFactory<ShoeShopDbContext>(options => options.UseOracle(Configuration.GetConnectionString("DEV"), 
                options => options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

            // Add services
            services.AddMudServices();

            services.AddScoped<GoogleDriveService>();
            services.AddSingleton<ShoeConfigService>();
            services.AddScoped<UserManagerService>();

            // Realtime service
            services.AddScoped<OrderRealtimeService>();

            // Repository
            services.AddSingleton<ShoeRepository>();
            services.AddSingleton<UserRepository>();
            services.AddSingleton<SizeRepository>();
            services.AddSingleton<ShoeSizeRepository>();
            services.AddSingleton<ImageRepository>();
            services.AddSingleton<ShoeCatalogRepository>();
            services.AddSingleton<OrderRepository>();
            services.AddSingleton<OrderDetailsRepository>();

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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
