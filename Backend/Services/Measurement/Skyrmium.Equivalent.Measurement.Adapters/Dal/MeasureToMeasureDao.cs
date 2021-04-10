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
         mappingExpression.ForMember(d => d.OwnedBy, cfg => cfg.MapFrom(e => e.OwnedBy.Value));
      }

      protected override void ContinueDaoToEntity(IMappingExpression<MeasureDao, Measure> mappingExpression)
      {
         mappingExpression.ConstructUsing((d, context) => 
            new Measure(
               d.Id,
               context.Mapper.Map<Guid?, IDistributableId>(d.DistributedId),
               context.Mapper.Map<Guid?, IDistributableId>(d.OwnedBy),
               d.FullName,
               d.ShortName
            ));

         mappingExpression.ForMember(e => e.OwnedBy, cfg => cfg.MapFrom(d => d.OwnedBy));
         mappingExpression.ForPath(e => e.OwnedBy.Value, cfg => cfg.MapFrom(d => d.OwnedBy));
      }
   }
}
