namespace LoggingSample;

public class ColoredConsoleLoggerConfiguration
{
    public LogLevel LogLevel { get; set; } = LogLevel.Warning;

    public int EventId { get; set; } = 0;

    public ConsoleColor MessageColor { get; set; } = ConsoleColor.Yellow;
}
