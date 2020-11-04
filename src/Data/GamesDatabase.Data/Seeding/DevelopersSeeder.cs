using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GamesDatabase.Data.Seeding
{
    internal class DevelopersSeeder : ISeeder
    {
        public Task SeedAsync(GamesDatabaseContext dbContext, IServiceProvider serviceProvider)
        {
            throw new NotImplementedException();
        }
    }
}