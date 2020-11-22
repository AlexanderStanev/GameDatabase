using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDatabase.Data.Seeding
{
    public class GamesDatabaseContextSeeder
    {
        public async Task SeedAsync(GamesDatabaseContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            //var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger(typeof(GamesDatabaseContextSeeder));

            var seeders = new List<ISeeder>
            {
                new RolesSeeder(),
                new UsersSeeder(),
                //new GamesSeeder(),
                new GenresSeeder(),
                //new DevelopersSeeder(),
                //new PublishersSeeder(),
                //new GameEnginesSeeder(),
                //new PlatformsSeeder(),
                //new TagsSeeder(),
            };

            foreach (var seeder in seeders)
            {
                await seeder.SeedAsync(dbContext, serviceProvider);
                await dbContext.SaveChangesAsync();
                // logger.LogInformation($"Seeder {seeder.GetType().Name} done.");
            }
        }
    }
}