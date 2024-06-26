using EquityAfia.PaymentsAndBillings.Application.Interfaces.Mapping;
using Mapster;
using MapsterMapper;
using System;

namespace EquityAfia.PaymentsAndBillings.Infrastructure.Mapping
{
    public class MapsterMapper : IMapper
    {
        private readonly TypeAdapterConfig _config;

        public TypeAdapterConfig Config => _config;

        public MapsterMapper(TypeAdapterConfig config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public TDestination Map<TDestination>(object source)
        {
            return _config.Adapt<TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _config.Adapt<TSource, TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _config.Adapt(source, destination);
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return _config.Adapt(source, sourceType, destinationType);
        }

        public object Map(object source, object destination, Type sourceType, Type destinationType)
        {
            return _config.Adapt(source, destination, sourceType, destinationType);
        }

        public ITypeAdapterBuilder<TSource, TDestination> From<TSource, TDestination>(TSource source)
        {
            return _config.ForType<TSource, TDestination>();
        }

        public ITypeAdapterBuilder<TSource> From<TSource>()
        {
            return _config.ForType<TSource>();
        }
    }
}
