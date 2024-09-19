using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseKestrel(options =>
{
    options.Listen(IPAddress.Loopback, 5000);
    options.Listen(IPAddress.Loopback, 5001, listenOptions =>
    {
        listenOptions.UseHttps("certificate.pfx", "password");
    });
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
