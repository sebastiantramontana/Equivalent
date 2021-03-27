using AutoMapper;
using Skyrmium.Adapters.Implementations.EntitiesToDaos;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   internal class MeasureToMeasureDao : EntityToDaoBase<Measure, MeasureDao>
   {
      protected override void ContinueEntityToDao(IMappingExpression<Measure, MeasureDao> mappingExpression)
      {
      }

      protected override void ContinueDaoToEntity(IMappingExpression<MeasureDao, Measure> mappingExpression)
      {
      }
   }
}
