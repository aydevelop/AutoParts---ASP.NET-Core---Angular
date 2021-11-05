using Database;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;

        public TaskRunner(ILogger<TaskRunner> logger, IServiceProvider provider, IConfiguration configuration)
        {
            _logger = logger;
            _db = provider.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
            _logger.LogInformation("HostedService Service is init");
            _configuration = configuration;
        }

        private void DoWork(object state)
        {
            var section = _configuration.GetSection("Providers");
            _logger.LogInformation("Task Start");
            new AutokladUa(_db, _logger, section["Autoklad"]).Run();
            new TemanComUa(_db, _logger, section["Teman"]).Run();
            new AutocompassComUa(_db, _logger, section["Autocompass"]).Run();
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
