namespace HostedServiceSample;

public class SampleBackgroundService : BackgroundService
{
    private readonly ILogger<SampleBackgroundService> _logger;

    public SampleBackgroundService(ILogger<SampleBackgroundService> logger)
    {
        _logger = logger;
    }

    public override async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Background service starting.");

        await base.StartAsync(cancellationToken);
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Background service starting.");

        await Task.Factory.StartNew(async () =>
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                _logger.LogInformation("Background service is executing at {DateTime}.", DateTime.Now);

                try
                {
                    await Task.Delay(2000, cancellationToken);
                }
                catch (OperationCanceledException) { }
            }
        });
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Background service stopping.");

        await base.StopAsync(cancellationToken);
    }
}
