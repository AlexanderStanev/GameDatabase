using GamesDatabase.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GamesDatabase.Data.Seeding
{
    internal class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(GamesDatabaseContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            await SeedUserAsync(userManager);
        }

        private static async Task SeedUserAsync(UserManager<ApplicationUser> userManager)
        {
            var seedingData = JObject.Parse(File.ReadAllText("SeedingData.json"));
            var usersData = seedingData["Users"].Children().ToList();

            foreach (var userData in usersData)
            {
                var deserializedUser = userData.ToObject<UserData>();

                if (await userManager.FindByNameAsync(deserializedUser.UserName) == null)
                {
                    var user = new ApplicationUser()
                    {
                        UserName = deserializedUser.UserName,
                        Email = deserializedUser.Email,
                    };

                    var userCreation = await userManager.CreateAsync(user, deserializedUser.Password);
                    if (!userCreation.Succeeded)
                    {
                        throw new Exception(string.Join(Environment.NewLine, userCreation.Errors.Select(e => e.Description)));
                    }

                    var roleAssigning = await userManager.AddToRoleAsync(user, deserializedUser.Role);
                    if (!roleAssigning.Succeeded)
                    {
                        throw new Exception(string.Join(Environment.NewLine, roleAssigning.Errors.Select(e => e.Description)));
                    }
                }
            };
        }
    }

    internal class UserData
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}

