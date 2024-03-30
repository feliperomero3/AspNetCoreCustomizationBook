namespace LoggingSample;

public class ColoredConsoleLogger : ILogger
{
    private readonly ColoredConsoleLoggerConfiguration _config;

    private static readonly object _lock = new();

    private readonly string _categoryName;

    public ColoredConsoleLogger(string categoryName, ColoredConsoleLoggerConfiguration config)
    {
        _categoryName = categoryName;
        _config = config;
    }

    public IDisposable BeginScope<TState>(TState state)
    {
        return null!;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return logLevel == _config.LogLevel;
    }

    public void Log<TState>(
        LogLevel logLevel,
        EventId eventId,
        TState state,
        Exception? exception,
        Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel))
        {
            return;
        }

        // We now need to lock the actual console output – this is because we will encounter
        // some race conditions where incorrect log entries get colored with the wrong color,
        // as the console itself is not really thread - safe.
        lock (_lock)
        {
            if (_config.EventId == 0 || _config.EventId == eventId.Id)
            {
                var color = Console.ForegroundColor;

                Console.ForegroundColor = _config.MessageColor;

                Console.Write($"{logLevel} - ");
                Console.Write($"{_categoryName}[{eventId.Id}] - ");
                Console.Write($"{formatter(state, exception)}\n");

                Console.ForegroundColor = color;
            }
        }
    }
}
