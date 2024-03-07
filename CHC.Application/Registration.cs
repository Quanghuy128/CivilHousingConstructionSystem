using Autofac;
using CHC.Domain.Common;
using CHC.Domain.Dtos.Interior;
using CHC.Domain.Dtos.InteriorDetail;
using CHC.Domain.Dtos.Material;
using CHC.Domain.Entities;
using Mapster;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CHC.Application
{
    public static class Registration
    {
        

        public static void RegisterMapster(this ContainerBuilder builder)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Default.IgnoreNullValues(true);

            var assemblies = new Assembly[]
            {
                Assembly.GetExecutingAssembly(),
                typeof(BaseEntity).Assembly
            };

            config = config.ConfigCustomMapper();

            config.Scan(assemblies);

            builder.RegisterInstance(config).SingleInstance();
            builder.RegisterType<ServiceMapper>().As<IMapper>().InstancePerLifetimeScope();
        }

        private static TypeAdapterConfig ConfigCustomMapper(this TypeAdapterConfig config)
        {
            config.NewConfig<Interior, InteriorDto>()
                .Map(dest => dest.Materials, src => src.InteriorDetails.Adapt<MaterialDto>())
                .Map(dest => dest.Quotations, src => src.Quotations);
            config.NewConfig<InteriorDetail, InteriorDetailDto>()
                .Map(dest => dest.Material, src => src.Material);
            return config;
        }
    }
}
