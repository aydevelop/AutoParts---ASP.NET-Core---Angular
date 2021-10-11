using Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
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

            var context = services.GetRequiredService<StoreDbContext>();
            var logger = services.GetRequiredService<ILogger<Program>>();

            //new AutokladUa(context).Run();

            try
            {
                await context.Database.MigrateAsync();
                await DbSeed.SeedAsync(context);
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
