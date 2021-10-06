using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Provider.Base
{

    public class HostedService : IHostedService, IDisposable
    {
        private readonly ILogger<HostedService> _logger;
        private Timer _timer;

        public HostedService(ILogger<HostedService> logger)
        {
            _logger = logger;
        }

        private void DoWork(object state)
        {
            _logger.LogInformation("DoWork");
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("HostedService Service is running");
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("HostedService is stopping");
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
