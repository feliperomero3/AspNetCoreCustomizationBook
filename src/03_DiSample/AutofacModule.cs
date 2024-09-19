using Autofac;

namespace DiSample;

public class AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ValuesService>().As<IValuesService>().InstancePerLifetimeScope();
    }
}
