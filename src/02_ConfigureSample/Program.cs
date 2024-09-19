using ConfigureSample;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddIniFile("appsettings.ini", optional: false, reloadOnChange: true);

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

var app = builder.Build();

var settings = app.Services.GetRequiredService<IOptions<AppSettings>>().Value;

app.MapGet("/", () => $"Foo: {settings.Foo}, Bar: {settings.Bar}");

app.Run();
