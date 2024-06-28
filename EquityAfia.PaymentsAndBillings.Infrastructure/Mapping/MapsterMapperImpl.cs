using System;
using EquityAfia.PaymentsAndBillings.Contracts.Billing;
using EquityAfia.PaymentsAndBillings.Domain.Entities;
using Mapster;

namespace EquityAfia.PaymentsAndBillings.Infrastructure.Mapping
{
    public class MapsterMapperImpl : IMapper
    {
        private readonly TypeAdapterConfig _config;

        public MapsterMapperImpl(TypeAdapterConfig config)
        {
            _config = config;
            ConfigureMappings(_config);
        }

        private static void ConfigureMappings(TypeAdapterConfig config)
        {
            // Configure global settings if needed
            TypeAdapterConfig.GlobalSettings.Default.NameMatchingStrategy(NameMatchingStrategy.Flexible);

            // Example of mapping configuration between types
            config.NewConfig<BillingDto, Billing>()
                .Map(dest => dest.BillingId, src => src.BillingId)
                .Map(dest => dest.AmountBilled, src => src.AmountBilled)
                .Map(dest => dest.CustomerId, src => src.CustomerId)
                .Map(dest => dest.CustomerName, src => src.CustomerName)
                .Map(dest => dest.CustomerEmail, src => src.CustomerEmail)
                .Map(dest => dest.Products, src => src.Products)
                .Map(dest => dest.Services, src => src.Services);
        }

        public TDestination Map<TDestination>(object source)
        {
            return source.Adapt<TDestination>(_config);
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return source.Adapt<TSource, TDestination>(_config);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return source.Adapt(destination, _config);
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return source.Adapt(sourceType, destinationType, _config);
        }

        public object Map(object source, object destination, Type sourceType, Type destinationType)
        {
            return source.Adapt(destination, sourceType, destinationType, _config);
        }

        public TypeAdapterConfig Config => _config;

        public TypeAdapterBuilder<TSource> From<TSource>(TSource source)
        {
            
            return TypeAdapterBuilder<TSource>.New().Map(_config);
        }
    }
}
