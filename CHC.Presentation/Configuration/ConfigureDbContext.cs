using Autofac;
using CHC.Infrastructure;
using FAB.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data;

namespace CHC.Presentation.Configuration
{
    public static class ConfigureDbContext
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(AppConfig.ConnectionStrings.DefaultConnection));
            return services;
        }

        public static ContainerBuilder AddDbContext(this ContainerBuilder builder)
        {
            builder.Register(c => new NpgsqlConnection(AppConfig.ConnectionStrings.DefaultConnection))
                    .As<IDbConnection>()
                    .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().As<DbContext>().InstancePerLifetimeScope();
            return builder;
        }
    }
}
