using AutoMapper;
using GamesDatabase.Data;
using GamesDatabase.Data.Core;
using GamesDatabase.Data.Models;
using GamesDatabase.Data.Seeding;
using GamesDatabase.Services.DataServices.Interfaces;
using GamesDatabase.Services.DataServices.Services;
using GamesDatabase.Services.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace GamesDatabase.Web
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
            AutoMapperConfig.RegisterMappings();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<GamesDatabaseContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<GamesDatabaseUser, IdentityRole>(
                o =>
                {
                    o.SignIn.RequireConfirmedEmail = false;
                    o.Password.RequireLowercase = false;
                    o.Password.RequireUppercase = false;
                    o.Password.RequireNonAlphanumeric = false;
                    o.Password.RequireDigit = false;
                    o.Password.RequiredUniqueChars = 0;
                    o.Password.RequiredLength = 3;

                })
                .AddDefaultTokenProviders()
                .AddDefaultUI()
                .AddEntityFrameworkStores<GamesDatabaseContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddLogging();
            services.AddAutoMapper();

            //services.Configure<RouteOptions>(routeOptions =>
            //{
            //    routeOptions.ConstraintMap.Add("code", typeof(CustomRouteConstraint));
            //});

            // Application services
            services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
            services.AddScoped<IGamesService, GamesService>();
            services.AddScoped<IGenresService, GenresService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env
            )
        {

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<GamesDatabaseContext>();

                //if (env.IsDevelopment())
                //{
                //    dbContext.Database.Migrate();
                //}

                if (!dbContext.Users.Any())
                {
                    new GamesDatabaseContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
                }
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller}/{action}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
