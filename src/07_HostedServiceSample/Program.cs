using HostedServiceSample;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IHostedService, SampleHostedService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
