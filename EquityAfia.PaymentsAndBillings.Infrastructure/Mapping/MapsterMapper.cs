using Mapster;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquityAfia.PaymentsAndBillings.Infrastructure.Mapping
{
    public class MapsterMapper : IMapper
    {
        private readonly TypeAdapterConfig _config;
        public MapsterMapper(TypeAdapterConfig config)

    }
    _config = config;
}
public TDestination Map<TSource, TDestination>(TSource source)
{
    return source.Adapt<TSource, TDestination>(_config);
}
