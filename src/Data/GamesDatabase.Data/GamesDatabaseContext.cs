using System;
using System.Collections.Generic;
using System.Text;
using GamesDatabase.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GamesDatabase.Data
{
    public class GamesDatabaseContext : IdentityDbContext<GamesDatabaseUser>
    {
        public GamesDatabaseContext(DbContextOptions<GamesDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

    }
}
