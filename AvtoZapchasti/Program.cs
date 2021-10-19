using Database;
using Microsoft.AspNetCore.Hosting;
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
            var config = services.GetRequiredService<IConfiguration>();
            loggerFactory.AddFile(Path.Combine($"{Directory.GetCurrentDirectory()}", config["logfile"]));

            //var taskLogger = services.GetRequiredService<ILogger<TaskRunner>>();
            //new AutokladUa(db, taskLogger).Run();

            try
            {
                await db.Database.MigrateAsync();
                await DbSeed.SeedAsync(db);
                logger.LogInformation("Migration completed");
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
