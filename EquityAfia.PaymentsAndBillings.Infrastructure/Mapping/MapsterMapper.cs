using EquityAfia.PaymentsAndBillings.Application.Interfaces.Mapping;
using Mapster;
using MapsterMapper;
using System;

namespace EquityAfia.PaymentsAndBillings.Infrastructure.Mapping
{
    public class MapsterMapper : IMapper
    {
        private readonly TypeAdapterConfig _config;

        public TypeAdapterConfig Config => throw new NotImplementedException();

        public MapsterMapper(TypeAdapterConfig config)
        {
            _config = config;
        }

        public TDestination Map<TDestination>(object source)
        {
            return source.Adapt<TDestination>();
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return source.Adapt<TDestination>();
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return source.Adapt(destination);
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return source.Adapt(destinationType, null, sourceType);
        }

        public object Map(object source, object destination, Type sourceType, Type destinationType)
        {
            return source.Adapt(destination, sourceType, destinationType);
        }

        public ITypeAdapterBuilder<TSource, TDestination> From<TSource, TDestination>(TSource source)
        {
            return _config.ForType<TSource, TDestination>();
        }

        public ITypeAdapterBuilder<TSource> From<TSource>(TSource source)
        {
            throw new NotImplementedException();
        }
    }
}
