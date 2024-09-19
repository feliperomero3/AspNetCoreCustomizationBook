using Autofac;
using Autofac.Extensions.DependencyInjection;
using DiSample;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Register services directly with Autofac here. Don't
// call builder.Populate(), that happens in AutofacServiceProviderFactory.
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacModule()));

var app = builder.Build();

var myService = app.Services.GetRequiredService<IValuesService>();

app.MapGet("/", (IValuesService service) =>
{
    _ = service.GetValues();
    return "Hello dependency injection sample!";
});

app.Run();
