using Database;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Provider.Base
{

    public class TaskRunner : IHostedService, IDisposable
    {
        private readonly ILogger<TaskRunner> _logger;
        private readonly AppDbContext _db;
        private Timer _timer;

        public TaskRunner(ILogger<TaskRunner> logger, IServiceProvider provider)
        {
            _logger = logger;
            _db = provider.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
            _logger.LogInformation("HostedService Service is init");
        }

        private void DoWork(object state)
        {
            _logger.LogInformation("Task Start");
            new AutokladUa(_db, _logger).Run();
            new TemanComUa(_db, _logger).Run();
            new AvtozoomComUa(_db, _logger).Run();
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("HostedService Service is start");
            _timer = new Timer(DoWork, null, TimeSpan.FromHours(24), TimeSpan.FromHours(24));
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
            _db?.Dispose();
        }
    }
}
