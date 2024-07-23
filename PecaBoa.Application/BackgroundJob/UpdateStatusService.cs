using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PecaBoa.Infra.Context;

namespace PecaBoa.Application.BackgroundJob;

public class UpdateStatusService : IHostedService, IDisposable
{
    private Timer _timer;
    private readonly ILogger<UpdateStatusService> _logger;
    private readonly IServiceProvider _serviceProvider;

    public UpdateStatusService(ILogger<UpdateStatusService> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Serviço de atualização de status iniciado.");
        _timer = new Timer(UpdateStatus, null, TimeSpan.Zero, TimeSpan.FromMinutes(2));
        return Task.CompletedTask;
    }

    private void UpdateStatus(object state)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var now = DateTime.Now;
            var records = dbContext.Pedidos.Where(r => r.StatusId != 4 && r.DataFim <= now).ToList();

            foreach (var record in records)
            {
                record.StatusId = 4;
            }

            dbContext.SaveChanges();
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Serviço de atualização de status parado.");
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}