using AutoMapper;
using Skyrmium.Adapters.Implementations.EntitiesToDaos;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using System.Linq;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   internal class ConversionToConversionDao : OwnedEntityToOwnedDaoBase<Conversion, ConversionDao>
   {
      protected override void ContinueWithOwnedDao(IMappingExpression<ConversionDao, Conversion> mappingExpression)
      {
         mappingExpression.ForMember(e => e.Name, c => c.MapFrom(d => d.Name));
         mappingExpression.ForMember(e => e.Equivalences, c => c. MapFrom(d => d.Equivalences));
      }

      protected override void ContinueWithOwnedEntity(IMappingExpression<Conversion, ConversionDao> mappingExpression)
      {
         mappingExpression.ForMember(d => d.Name, c => c.MapFrom(e => e.Name));
         mappingExpression.ForMember(d => d.Equivalences, c => c.MapFrom(e => e.Equivalences));
      }
   }
}
