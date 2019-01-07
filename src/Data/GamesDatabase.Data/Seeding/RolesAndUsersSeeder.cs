using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GamesDatabase.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace GamesDatabase.Data.Seeding
{
    internal class RolesAndUsersSeeder : ISeeder
    {
        public async Task SeedAsync(GamesDatabaseContext dbContext, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<GamesDatabaseUser>>();

            await SeedRoleAsync(roleManager, "Administrator");
            await CreateAdminUser(userManager);

            await SeedRoleAsync(roleManager, "Moderator");
            await SeedRoleAsync(roleManager, "Gamer");
        }

        private static async Task SeedRoleAsync(RoleManager<IdentityRole> roleManager, string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                var result = await roleManager.CreateAsync(new IdentityRole(roleName));
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }

        private static async Task CreateAdminUser(UserManager<GamesDatabaseUser> userManager)
        {
             using (var r = new StreamReader("InitialUsers.json"))
            {
                var json = r.ReadToEnd();
                var admin = JsonConvert.DeserializeObject<AdminData>(json);

                var user = new GamesDatabaseUser()
                {
                    UserName = admin.Username,
                    Email = admin.Email,
                };

                var userCreation = await userManager.CreateAsync(user, admin.Password);

                if (!userCreation.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, userCreation.Errors.Select(e => e.Description)));
                }

                var roleAssigning = await userManager.AddToRoleAsync(user, "Administrator");

                if (!roleAssigning.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, roleAssigning.Errors.Select(e => e.Description)));
                }
            }
        }
    }

    internal class AdminData
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}