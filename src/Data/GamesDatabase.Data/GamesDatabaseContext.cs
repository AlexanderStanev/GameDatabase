using GamesDatabase.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GamesDatabase.Data
{
    public class GamesDatabaseContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public GamesDatabaseContext(DbContextOptions<GamesDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<ApplicationRole> ApplicationRoles { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Developer> Developers { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<GameEngine> GameEngines { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Video> Videos { get; set; }

        public DbSet<Platform> Platforms { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Release> Releases { get; set; }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
