using AutoMapper;
using Skyrmium.Adapters.Implementations.EntitiesToDaos;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   //TODO: REVIEW
   internal class ConversionToConversionDao : EntityToDaoBase<Conversion, ConversionDao>
   {
      protected override void ContinueDaoToEntity(IMappingExpression<ConversionDao, Conversion> mappingExpression)
      {
         //mappingExpression
         //   .ForMember(e => e.Name, c => c.MapFrom(d => d.Name))
         //   .ForMember(e => e.Equivalences, c => c.MapFrom(d => d.Equivalences));
      }

      protected override void ContinueEntityToDao(IMappingExpression<Conversion, ConversionDao> mappingExpression)
      {
         //mappingExpression
         //   .ForMember(d => d.Name, c => c.MapFrom(e => e.Name))
         //   .ForMember(d => d.Equivalences, c => c.MapFrom(e => e.Equivalences));
      }
   }
}
