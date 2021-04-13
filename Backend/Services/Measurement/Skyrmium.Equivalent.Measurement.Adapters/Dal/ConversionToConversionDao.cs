using AutoMapper;
using Skyrmium.Adapters.Implementations.EntitiesToDaos;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using System.Linq;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   internal class ConversionToConversionDao : OwnedEntityToDaoBase<Conversion, ConversionDao>
   {
      protected override void ContinueOwnedEntityToDao(IMappingExpression<Conversion, ConversionDao> mappingExpression)
      {
      }

      protected override void ContinueOwnedDaoToEntity(IMappingExpression<ConversionDao, Conversion> mappingExpression)
      {
         mappingExpression.ConstructUsing((dao, context) =>
            Conversion.Create(
               dao.Id,
               dao.DistributedId,
               dao.OwnedBy,
               dao.Name,
               dao.Equivalences.Select(eq => context.Mapper.Map<OrderedMeasureEquivalenceDao, OrderedMeasureEquivalence>(eq)).ToList()
            ));
      }
   }
}
