namespace HostedServiceSample;

public class SampleHostedService : IHostedService
{
    private readonly ILogger<SampleHostedService> _logger;

    public SampleHostedService(ILogger<SampleHostedService> logger)
    {
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Hosted service starting.");

        return Task.Factory.StartNew(async () =>
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                _logger.LogInformation("Hosted service is executing at {DateTime}.", DateTime.Now);

                try
                {
                    await Task.Delay(2000);
                }
                catch (OperationCanceledException) { }

            }
        }, cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Hosted service stopping.");

        return Task.CompletedTask;
    }
}
