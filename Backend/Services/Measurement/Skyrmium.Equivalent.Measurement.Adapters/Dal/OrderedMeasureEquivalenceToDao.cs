using AutoMapper;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   internal class OrderedMeasureEquivalenceToDao : Profile
   {
      public OrderedMeasureEquivalenceToDao() : base()
      {
         CreateMap<OrderedMeasureEquivalence, OrderedMeasureEquivalenceDao>(MemberList.None);
         CreateMap<OrderedMeasureEquivalenceDao, OrderedMeasureEquivalence>(MemberList.None);
      }
   }
}
