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
    }
}
