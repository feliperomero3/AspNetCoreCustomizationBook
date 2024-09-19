using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseKestrel((host, options) =>
{
    var certificateFileName = host.Configuration["AppSettings:CertificateFileName"];
    var certificatePassword = host.Configuration["AppSettings:CertificatePassword"];

    options.Listen(IPAddress.Loopback, 5000);
    options.Listen(IPAddress.Loopback, 5001, listenOptions =>
    {
        listenOptions.UseHttps(certificateFileName, certificatePassword);
    });
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
