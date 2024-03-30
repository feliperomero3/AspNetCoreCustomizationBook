using LoggingSample;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();

var config = new ColoredConsoleLoggerConfiguration
{
    LogLevel = LogLevel.Information,
    MessageColor = ConsoleColor.Red
};

builder.Logging.AddProvider(new ColoredConsoleLoggerProvider(config));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
