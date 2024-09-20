using HostedServiceSample;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddSingleton<IHostedService, SampleHostedService>();

builder.Services.AddHostedService<SampleBackgroundService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
