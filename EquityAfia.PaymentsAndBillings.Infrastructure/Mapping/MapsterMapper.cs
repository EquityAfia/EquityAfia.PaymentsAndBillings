using EquityAfia.PaymentsAndBillings.Contracts.Billing;
using EquityAfia.PaymentsAndBillings.Domain.Entities;
using Mapster;

namespace EquityAfia.PaymentsAndBillings.Infrastructure.Mapping
{
    public static class MapsterMapper
    {
        private static TypeAdapterConfig _config;

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
            config.ForType<BillingDto, Billing>()
                .Map(dest => dest.BillingDto, src => src.BillingDto);
        }

        public static TDestination Map<TDestination>(object source)
        {
            return source.Adapt<TDestination>();
        }

        public static TDestination Map<TSource, TDestination>(TSource source)
        {
            return source.Adapt<TDestination>();
        }

        public static TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return source.Adapt(destination);
        }

        public static object Map(object source, Type sourceType, Type destinationType)
        {
            return source.Adapt(destinationType, null, sourceType);
        }

        public static object Map(object source, object destination, Type sourceType, Type destinationType)
        {
            return source.Adapt(destination, sourceType, destinationType);
        }

        public static ITypeAdapterBuilder<TSource, TDestination> From<TSource, TDestination>(TSource source)
        {
            return _config.ForType<TSource, TDestination>();
        }
    }
}
