using GamesDatabase.Data.Models;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GamesDatabase.Data.Seeding
{
    internal class GenresSeeder : ISeeder
    {
        public async Task SeedAsync(GamesDatabaseContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Genres.Any())
            {
                await SeedGenresAsync(dbContext);
            }
        }

        private async Task SeedGenresAsync(GamesDatabaseContext dbContext)
        {
            var seedingData = JObject.Parse(File.ReadAllText("SeedingData.json"));
            var genresData = seedingData["Genres"].Children().ToList();

            foreach (var genreData in genresData)
            {
                var deserializedGenre = genreData.ToObject<Genre>();
                await dbContext.Genres.AddAsync(deserializedGenre);
            }
        }
    }
}