using Autofac;
using CHC.Domain.Common;
using CHC.Domain.Dtos.Contract;
using CHC.Domain.Dtos.Interior;
using CHC.Domain.Dtos.InteriorDetail;
using CHC.Domain.Dtos.Material;
using CHC.Domain.Dtos.Quotation;
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
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Materials, src => src.InteriorDetails.Adapt<MaterialViewModel>())
                .Map(dest => dest.Quotations, src => src.Quotations);
            config.NewConfig<Quotation, QuotationDto>()
                .Map(dest => dest.Interior, src => src.Interior.Adapt<InteriorViewModel>())
                .Map(dest => dest.Interior.InteriorDetails, src => src.Interior.InteriorDetails.Adapt<ICollection<InteriorDetailViewModel>>())
                .Map(dest => dest.Interior.Materials, src => src.Interior.InteriorDetails.Select(x => x.Material))
                .IgnoreNullValues(true);
            config.NewConfig<UpdateQuotationRequest, Quotation>()
                .IgnoreIf((src, dest) => dest.Customer != null, dest => dest.Customer);
            config.NewConfig<InteriorDetail, InteriorDetailDto>()
                .Map(dest => dest.Material, src => src.Material)
                .Map(dest => dest.Interior, src => src.Interior);
            config.NewConfig<Material, MaterialDto>();
            config.NewConfig<Material, MaterialViewModel>();
            config.NewConfig<UpdateContractRequest, ContractDto>()
                .Map(dest => dest.Status, src => src.Status);
            return config;
        }
    }
}
