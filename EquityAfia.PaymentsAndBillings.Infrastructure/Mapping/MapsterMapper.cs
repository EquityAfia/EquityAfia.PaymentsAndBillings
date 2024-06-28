using EquityAfia.PaymentsAndBillings.Contracts.Billing;
using EquityAfia.PaymentsAndBillings.Domain.Entities;
using Mapster;

namespace EquityAfia.PaymentsAndBillings.Infrastructure.Mapping
{
    public static class MapsterMapper
    {
        private static readonly TypeAdapterConfig _config;

        static MapsterMapper()
        {
            _config = new TypeAdapterConfig();
            // Configure mappings
            ConfigureMappings(_config);
        }

        public static void ConfigureMappings(TypeAdapterConfig config)
        {
            // Example of configuring a mapping
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

        public static TDestination Map<TDestination>(object source)
        {
            return source.Adapt<TDestination>(_config);
        }

        public static TDestination Map<TSource, TDestination>(TSource source)
        {
            return source.Adapt<TSource, TDestination>(_config);
        }

        public static TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return source.Adapt(destination, _config);
        }

        public static object Map(object source, Type sourceType, Type destinationType)
        {
            return source.Adapt(sourceType, destinationType, _config);
        }

        public static object Map(object source, object destination, Type sourceType, Type destinationType)
        {
            return source.Adapt(destination, sourceType, destinationType, _config);
        }

        public static TypeAdapterSetter<TSource, TDestination> From<TSource, TDestination>(TSource source)
        {
            return _config.NewConfig<TSource, TDestination>();
        }
    }
}
