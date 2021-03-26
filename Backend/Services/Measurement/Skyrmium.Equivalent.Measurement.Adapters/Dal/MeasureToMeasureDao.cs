using AutoMapper;
using Skyrmium.Adapters.Implementations.EntitiesToDaos;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   internal class MeasureToMeasureDao : OwnedEntityToOwnedDaoBase<Measure, MeasureDao>
   {
      protected override void ContinueOwnedEntityToOwnedDao(IMappingExpression<Measure, MeasureDao> mappingExpression)
      {
      }

      protected override void ContinueWithOwnedDaoToOwnedEntity(IMappingExpression<MeasureDao, Measure> mappingExpression)
      {
      }
   }
}
