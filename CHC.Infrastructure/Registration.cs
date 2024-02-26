using Autofac;
using CHC.Application.IService;
using CHC.Infrastructure.Repository;
using System.Reflection;

namespace CHC.Infrastructure
{
    public static class Registration
    {
        public static void RegisterRepository(this ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(GenericRepository<>))
                    .As(typeof(IGenericRepository<>)).InstancePerDependency();

            builder.RegisterGeneric(typeof(UnitOfWork<>)).As(typeof(IUnitOfWork<>)).InstancePerDependency();
        }
    }
}
