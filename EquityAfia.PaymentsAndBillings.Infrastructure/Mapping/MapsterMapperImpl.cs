using EquityAfia.PaymentsAndBillings.Contracts.Billing;
using EquityAfia.PaymentsAndBillings.Domain.Entities;
using Mapster;
using MapsterMapper;

namespace EquityAfia.PaymentsAndBillings.Infrastructure.Mapping
{
    public class MapsterMapperImpl : IMapper
    {
        private readonly TypeAdapterConfig _config;

        public MapsterMapperImpl(TypeAdapterConfig config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            ConfigureMappings(_config);
        }

        private void ConfigureMappings(TypeAdapterConfig config)
        {
            TypeAdapterConfig.GlobalSettings.Default.NameMatchingStrategy(NameMatchingStrategy.Flexible);

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
            return source.Adapt<TDestination>(_config); // Adapt to TDestination using _config
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return source.Adapt(destination, _config); // Adapt source to destination using _config
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return source.Adapt(sourceType, destinationType, _config); // Adapt using sourceType, destinationType, _config
        }

        public object Map(object source, object destination, Type sourceType, Type destinationType)
        {
            return source.Adapt(destination, sourceType, destinationType, _config); // Adapt using destination, sourceType, destinationType, _config
        }

        public ITypeAdapterBuilder<TSource, TDestination> From<TSource, TDestination>(TSource source)
        {
            return _config.ForType<TSource, TDestination>(); // Create a new config for TSource and TDestination
        }
    }
}
