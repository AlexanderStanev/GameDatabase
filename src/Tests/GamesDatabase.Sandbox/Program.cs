using System;
using System.IO;
using System.Text;
using GameDatabase.Data.Core;
using GamesDatabase.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sandbox
{
    public static class Program
    {
        public static void Main(string[] args)
        {
    //        Console.OutputEncoding = Encoding.UTF8;
    //        Console.WriteLine($"{typeof(Program).Namespace} ({string.Join(" ", args)}) starts working...");
    //        var serviceCollection = new ServiceCollection();
    //        ConfigureServices(serviceCollection);
    //        IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider(true);

    //        using (var serviceScope = serviceProvider.CreateScope())
    //        {
    //            serviceProvider = serviceScope.ServiceProvider;
    //            SandboxCode(serviceProvider);
    //        }
    //    }

    //    private static void SandboxCode(IServiceProvider serviceProvider)
    //    {
    //        var context = serviceProvider.GetService<>();

    //    }

    //    private static void ConfigureServices(ServiceCollection services)
    //    {
    //        var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
    //            .AddJsonFile("appsettings.json", false, true)
    //            .AddEnvironmentVariables()
    //            .Build();

    //        services.AddDbContext<GamesDatabaseContext>(options =>
    //            options.UseSqlServer(
    //                configuration.GetConnectionString("DefaultConnection")));

    //        services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
        }
    }
}