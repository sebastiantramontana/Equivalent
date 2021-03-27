using AutoMapper;
using Skyrmium.Adapters.Implementations.EntitiesToDaos;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   internal class ConversionToConversionDao : EntityToDaoBase<Conversion, ConversionDao>
   {
      protected override void ContinueEntityToDao(IMappingExpression<Conversion, ConversionDao> mappingExpression)
      {
         //TODO
         //mappingExpression
         //   .ForMember(d => d.Name, c => c.MapFrom(e => e.Name))
         //   .ForMember(d => d.Equivalences, c => c.MapFrom(e => e.Equivalences));
      }

      protected override void ContinueDaoToEntity(IMappingExpression<ConversionDao, Conversion> mappingExpression)
      {
         mappingExpression.ConstructUsing((dao, context) =>
            Conversion.Create(
               dao.Id,
               context.Mapper.Map<Guid?, IDistributableId>(dao.DistributedId),
               context.Mapper.Map<Guid?, IDistributableId>(dao.OwnedBy),
               dao.Name,
               dao.Equivalences.Select(eq => context.Mapper.Map<OrderedMeasureEquivalenceDao, OrderedMeasureEquivalence>(eq)).ToList()
            ));
      }
   }
}
