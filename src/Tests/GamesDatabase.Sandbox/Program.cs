using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using CommandLine;
using GamesDatabase.Data;
using GamesDatabase.Data.Core;
using GamesDatabase.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Sandbox
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"{typeof(Program).Namespace} ({string.Join(" ", args)}) starts working...");
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider(true);

            using (var serviceScope = serviceProvider.CreateScope())
            {
                serviceProvider = serviceScope.ServiceProvider;
                SandboxCode(serviceProvider);
            }
        }

        private static void SandboxCode(IServiceProvider serviceProvider)
        {
            using (var r = new StreamReader("InitialUsers.json"))
            {
                var json = r.ReadToEnd();
                dynamic userData = JsonConvert.DeserializeObject(json);
                Console.WriteLine($"The user is: {userData.username}");
                Console.WriteLine($"The password is: {userData.password}");
                Console.WriteLine($"The email is: {userData.email}");
            }

            //var context = serviceProvider.GetService<GamesDatabaseContext>();

            //context.Genres.Add(new Genre()
            //{
            //    Description = "A game in which players assume the roles of characters in a fictional setting. Players take responsibility for acting out these roles within a narrative, either through literal acting or through a process of structured decision-making of character development.[3] Actions taken within many games succeed or fail according to a formal system of rules and guidelines",
            //    Name = "RPG"
            //});

            //context.Genres.Add(new Genre()
            //{
            //    Description = "A subgenre of strategy video games that originated as a subgenre of real-time strategy, in which a player controls a single character in a team who compete versus another team of players. The objective is to destroy the opposing team's main structure with the assistance of periodically-spawned computer-controlled units that march forward along set paths. Player characters typically have various abilities and advantages that improve over the course of a game and that contribute to a team's overall strategy.",
            //    Name = "MOBA"
            //});

            //context.Genres.Add(new Genre()
            //{
            //    Description = "An online game with large numbers of players, typically from hundreds to thousands, on the same server. MMOs usually feature a huge, persistent open world, although some games differ.",
            //    Name = "MMO"
            //});

            //context.Genres.Add(new Genre()
            //{
            //    Description = "Game which focuses on gameplay requiring careful and skillful thinking and planning in order to achieve victory and the action scales from world domination to squad-based tactics.",
            //    Name = "Strategy"
            //});

            //context.Genres.Add(new Genre()
            //{
            //    Description = "Games which emulate the playing of traditional physical sports. Some emphasize actually playing the sport, while others emphasize the strategy behind the sport. Others satirize the sport for comic effect.",
            //    Name = "Sports"
            //});

            //context.SaveChanges();

            //context.Games.Add(new Game()
            //{
            //    Title = "Witcher 5",
            //    Description = "A very cool game",
            //    Raiting = 3,
            //    Developer = "CD Projekt",
            //    DateReleased = DateTime.Now,
            //    ReviewsCount = 2,
            //    Genres = new List<Genre>()

            //});


            //WebRequest();

        }

        private static void ConfigureServices(ServiceCollection services)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                //.AddEnvironmentVariables()
                .Build();

            services.AddDbContext<GamesDatabaseContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
        }

        private static void WebRequest()
        {
            const string WEBSERVICE_URL = "https://api-v3.igdb.com/games/";
            try
            {
                var webRequest = System.Net.WebRequest.Create(WEBSERVICE_URL);
                if (webRequest != null)
                {
                    webRequest.Method = "Post";
                    webRequest.Timeout = 300000;
                    webRequest.ContentType = "application/json";
                    webRequest.Headers.Add("user-key", "004d3f0efdd354f2dd58497a3a981166");

                    using (Stream s = webRequest.GetResponse().GetResponseStream())
                    {
                        using (StreamReader sr = new StreamReader(s))
                        {
                            var jsonResponse = sr.ReadToEnd();
                            Console.WriteLine(String.Format("Response: {0}", jsonResponse));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}