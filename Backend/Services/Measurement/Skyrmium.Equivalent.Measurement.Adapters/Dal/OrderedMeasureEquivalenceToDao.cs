using AutoMapper;
using Skyrmium.Adapters.Implementations.EntitiesToDaos;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   internal class OrderedMeasureEquivalenceToDao : EntityToDaoBase<OrderedMeasureEquivalence, OrderedMeasureEquivalenceDao>
   {
      protected override void ContinueDaoToEntity(IMappingExpression<OrderedMeasureEquivalenceDao, OrderedMeasureEquivalence> mappingExpression)
      {
      }

      protected override void ContinueEntityToDao(IMappingExpression<OrderedMeasureEquivalence, OrderedMeasureEquivalenceDao> mappingExpression)
      {
         mappingExpression.ForMember(d => d.Conversion, cfg => cfg.Ignore());
      }
   }
}
