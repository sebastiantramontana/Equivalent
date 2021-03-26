using AutoMapper;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   //TODO: REVISAR TODO!!!
   internal class OrderedMeasureEquivalenceToDao : Profile
   {
      public OrderedMeasureEquivalenceToDao() : base()
      {
         CreateMap<OrderedMeasureEquivalence, OrderedMeasureEquivalenceDao>(MemberList.None)
            .ForMember(d => d.Conversion, cfg => cfg.Ignore());
         //.ForMember(d => d.Order, cfg => cfg.MapFrom(e => e.Order))
         //.ForMember(d => d.MeasureEquivalence, cfg => cfg.MapFrom(e => e.MeasureEquivalence));

         CreateMap<OrderedMeasureEquivalenceDao, OrderedMeasureEquivalence>(MemberList.None);
            //.ForMember(e => e.Order, cfg => cfg.MapFrom(d => d.Order))
            //.ForMember(e => e.MeasureEquivalence, cfg => cfg.MapFrom(d => d.MeasureEquivalence));
      }
   }
}
