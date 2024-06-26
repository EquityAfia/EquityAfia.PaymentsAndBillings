using Mapster;
using MapsterMapper;
using System;

namespace EquityAfia.PaymentsAndBillings.Infrastructure.Mapping
{
    public class MapsterMapper : IMapper
    {
        private readonly TypeAdapterConfig _config;
        private readonly MapsterMapper.Mapper _mapper;

        public MapsterMapper(TypeAdapterConfig config)
        {
            _config = config;
            _mapper = new MapsterMapper.Mapper(_config);
        }

        public TDestination Map<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _mapper.Map(source, destination);
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return _mapper.Map(source, sourceType, destinationType);
        }

        public object Map(object source, object destination, Type sourceType, Type destinationType)
        {
            return _mapper.Map(source, destination, sourceType, destinationType);
        }

        public TypeAdapterBuilder<TSource> From<TSource>(TSource source)
        {
            return _mapper.From(source);
        }

        public TypeAdapterConfig Config => _mapper.Config;
    }
}
