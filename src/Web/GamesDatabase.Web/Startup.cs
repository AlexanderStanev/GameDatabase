namespace GamesDatabase.Web
{
    using System.Reflection;
    using System.Threading.Tasks;
    using AutoMapper;
    using GameDatabase.Data;
    using GameDatabase.Data.Core;
    using GameDatabase.Data.Core.Repositories;
    using GamesDatabase.Data;
    using GamesDatabase.Data.Core;
    using GamesDatabase.Data.Models;
    using GamesDatabase.Data.Repositories;
    using GamesDatabase.Data.Seeding;
    using GamesDatabase.Services.DataServices.Interfaces;
    using GamesDatabase.Services.DataServices.Services;
    using GamesDatabase.Services.Mapping;
    using GamesDatabase.Web.Models.ViewModels;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GamesDatabaseContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, ApplicationRole>(IdentityOptionsProvider.GetIdentityOptions)
              .AddDefaultUI()
              .AddEntityFrameworkStores<GamesDatabaseContext>()
              .AddDefaultTokenProviders();

            services.Configure<CookiePolicyOptions>(
                options =>
                {
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });

            services.AddControllersWithViews(options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute())).AddRazorRuntimeCompilation();
            services.AddRazorPages();
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddSingleton(this.configuration);

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<Game>), typeof(EfDeletableEntityRepository<Game>));
            services.AddScoped(typeof(IDeletableEntityRepository<Genre>), typeof(EfDeletableEntityRepository<Genre>));
            services.AddScoped(typeof(IDeletableEntityRepository<GameGenre>), typeof(EfDeletableEntityRepository<GameGenre>));
            services.AddScoped(typeof(IDeletableEntityRepository<Review>), typeof(EfDeletableEntityRepository<Review>));
            services.AddScoped(typeof(IDeletableEntityRepository<ContactForm>), typeof(EfDeletableEntityRepository<ContactForm>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<IGamesService, GamesService>();
            services.AddTransient<IGenresService, GenresService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IReviewsService, ReviewsService>();
            services.AddTransient<IContactFormService, ContactFormService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<GamesDatabaseContext>();
                dbContext.Database.Migrate();

                new GamesDatabaseContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Temporary
            // app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapRazorPages();
                });
        }
    }
}
