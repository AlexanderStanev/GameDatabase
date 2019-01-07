using System;
using System.Threading.Tasks;

namespace GamesDatabase.Data.Seeding
{
    public interface ISeeder
    {
        Task SeedAsync(GamesDatabaseContext dbContext, IServiceProvider serviceProvider);
    }
}