using Mapster;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Infrastructure.Mapping
{
    public class MapsterMapperImpl : IMapper
    {
        private readonly TypeAdapterConfig _config;
        public MapsterMapperImpl(TypeAdapterConfig config)
        {
            _config = config;
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

