using AutoMapper;
using Skyrmium.Adapters.Implementations.EntitiesToDaos;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using System;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   internal class MeasureToMeasureDao : EntityToDaoBase<Measure, MeasureDao>
   {
      protected override void ContinueEntityToDao(IMappingExpression<Measure, MeasureDao> mappingExpression)
      {
         //mappingExpression.ForMember(d => d.OwnedBy, cfg => cfg.MapFrom(e => e.OwnedBy));
      }

      protected override void ContinueDaoToEntity(IMappingExpression<MeasureDao, Measure> mappingExpression)
      {
         mappingExpression.ForMember(e => e.OwnedBy, cfg => cfg.MapFrom(d => d.OwnedBy));
      }
   }
}
