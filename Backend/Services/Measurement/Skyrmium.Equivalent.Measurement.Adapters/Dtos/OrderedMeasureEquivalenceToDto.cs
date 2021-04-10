using AutoMapper;
using Skyrmium.Equivalent.Measurement.Api.Dtos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   internal class OrderedMeasureEquivalenceToDto : Profile
   {
      public OrderedMeasureEquivalenceToDto() : base()
      {
         CreateMap<OrderedMeasureEquivalence, OrderedMeasureEquivalenceDto>(MemberList.None);
         CreateMap<OrderedMeasureEquivalenceDto, OrderedMeasureEquivalence>(MemberList.None);
      }
   }
}
