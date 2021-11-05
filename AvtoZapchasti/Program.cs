using Database;
using Database.Model;
using Infrastructure.Provider.Base;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AvtoZapchasti
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var db = services.GetRequiredService<AppDbContext>();
            var logger = services.GetRequiredService<ILogger<Program>>();
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            IConfiguration config = services.GetRequiredService<IConfiguration>();
            loggerFactory.AddFile(Path.Combine($"{Directory.GetCurrentDirectory()}", config["logfile"]));

            var taskLogger = services.GetRequiredService<ILogger<TaskRunner>>();
            UserManager<AppUser> userManager = services.GetRequiredService<UserManager<AppUser>>();

            try
            {
                //await db.Database.EnsureDeletedAsync();
                await db.Database.MigrateAsync();
                await DbSeed.SeedAsync(db, userManager);
                logger.LogInformation("Migration completed");

                var section = config.GetSection("Providers");
                //new AutokladUa(db, taskLogger, section["Autoklad"]).Run();
                //new TemanComUa(db, taskLogger, section["Teman"]).Run();
                //new AutocompassComUa(db, taskLogger, section["Autocompass"]).Run();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occured during migration");
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
