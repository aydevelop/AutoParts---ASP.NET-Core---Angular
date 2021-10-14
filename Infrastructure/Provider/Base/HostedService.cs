using Database;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Provider.Base
{

    public class ProviderRunner : IHostedService, IDisposable
    {
        private readonly ILogger<ProviderRunner> _logger;
        private readonly StoreDbContext _db;
        //private Timer _timer;

        public ProviderRunner(ILogger<ProviderRunner> logger, IServiceProvider provider)
        {
            _logger = logger;
            _db = provider.CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();
            _logger.LogInformation("HostedService Service is init");
        }

        private void DoWork(object state)
        {
            _logger.LogInformation("DoWork");
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("HostedService Service is start");
            //_timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    await Task.Delay(1000 * 60 * 60 * 24);
                    new AutokladUa(_db, _logger).Run();
                }
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("HostedService is stopping");
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //_timer?.Dispose();
            _db?.Dispose();
        }
    }
}
