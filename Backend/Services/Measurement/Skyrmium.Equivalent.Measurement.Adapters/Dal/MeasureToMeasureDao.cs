using AutoMapper;
using Skyrmium.Adapters.Implementations.EntitiesToDaos;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using System;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   internal class MeasureToMeasureDao : OwnedEntityToDaoBase<Measure, MeasureDao>
   {
      protected override void ContinueOwnedEntityToDao(IMappingExpression<Measure, MeasureDao> mappingExpression)
      {
      }

      protected override void ContinueOwnedDaoToEntity(IMappingExpression<MeasureDao, Measure> mappingExpression)
      {
      }
   }
}
