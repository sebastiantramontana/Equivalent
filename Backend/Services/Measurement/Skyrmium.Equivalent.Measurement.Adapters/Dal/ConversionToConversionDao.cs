using AutoMapper;
using Skyrmium.Adapters.Implementations.EntitiesToDaos;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   //TODO: REVIEW
   internal class ConversionToConversionDao : OwnedEntityToOwnedDaoBase<Conversion, ConversionDao>
   {
      protected override void ContinueWithOwnedDaoToOwnedEntity(IMappingExpression<ConversionDao, Conversion> mappingExpression)
      {
         //mappingExpression
         //   .ForMember(e => e.Name, c => c.MapFrom(d => d.Name))
         //   .ForMember(e => e.Equivalences, c => c.MapFrom(d => d.Equivalences));
      }

      protected override void ContinueOwnedEntityToOwnedDao(IMappingExpression<Conversion, ConversionDao> mappingExpression)
      {
         //mappingExpression
         //   .ForMember(d => d.Name, c => c.MapFrom(e => e.Name))
         //   .ForMember(d => d.Equivalences, c => c.MapFrom(e => e.Equivalences));
      }
   }
}
