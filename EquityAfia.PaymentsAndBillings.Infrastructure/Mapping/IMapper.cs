﻿using Mapster;

namespace EquityAfia.PaymentsAndBillings.Infrastructure.Mapping
{
    public interface IMapper
    {
        TDestination Map<TDestination>(object source);
        TDestination Map<TSource, TDestination>(TSource source);
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
        object Map(object source, Type sourceType, Type destinationType);
        object Map(object source, object destination, Type sourceType, Type destinationType);
        TypeAdapterConfig Config { get; }
        TypeAdapterBuilder<TSource> From<TSource>(TSource source);
    }
}
