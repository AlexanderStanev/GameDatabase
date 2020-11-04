using GamesDatabase.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GamesDatabase.Data.Seeding
{
    internal class RolesSeeder : ISeeder
    {
        public async Task SeedAsync(GamesDatabaseContext dbContext, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            await SeedRoleAsync(roleManager, Common.GlobalConstants.AdministratorRoleName);
            await SeedRoleAsync(roleManager, Common.GlobalConstants.ModeratorRoleName);
            await SeedRoleAsync(roleManager, Common.GlobalConstants.GamerRoleName);
        }

        private static async Task SeedRoleAsync(RoleManager<ApplicationRole> roleManager, string roleName)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                var result = await roleManager.CreateAsync(new ApplicationRole(roleName));
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}