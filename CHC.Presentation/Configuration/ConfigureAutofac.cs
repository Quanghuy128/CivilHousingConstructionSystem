using Autofac.Extensions.DependencyInjection;
using Autofac;
using CHC.Presentation.Configuration;

namespace FAB.API.Configurations
{
    public static class ConfigureAutofac
    {
        public static void ConfigureAutofacContainer(this WebApplicationBuilder builder)
        {
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(container =>
            {
                container.RegisterModule(new AutofacModule());
            });
        }
    }
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.AddDbContext();
            base.Load(builder);
        }
    }
}