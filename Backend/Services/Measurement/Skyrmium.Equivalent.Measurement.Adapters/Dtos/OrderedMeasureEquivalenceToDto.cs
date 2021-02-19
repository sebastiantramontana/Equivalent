﻿using AutoMapper;
using Skyrmium.Equivalent.Measurement.Api.Dtos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   internal class OrderedMeasureEquivalenceToDto : Profile
   {
      public OrderedMeasureEquivalenceToDto() : base()
      {
         CreateMap<OrderedMeasureEquivalence, OrderedMeasureEquivalenceDto>(MemberList.None)
            .ForMember(d => d.Order, cfg => cfg.MapFrom(e => e.Order))
            .ForMember(d => d.MeasureEquivalence, cfg => cfg.MapFrom(e => e.MeasureEquivalence));

         CreateMap<OrderedMeasureEquivalenceDto, OrderedMeasureEquivalence>(MemberList.None)
            .ForMember(e => e.Order, cfg => cfg.MapFrom(d => d.Order))
            .ForMember(e => e.MeasureEquivalence, cfg => cfg.MapFrom(d => d.MeasureEquivalence));
      }
   }
}
