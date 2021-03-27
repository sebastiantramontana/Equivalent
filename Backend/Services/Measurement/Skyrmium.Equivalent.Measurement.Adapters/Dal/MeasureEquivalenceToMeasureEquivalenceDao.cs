using AutoMapper;
using Skyrmium.Adapters.Implementations.EntitiesToDaos;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using System;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   internal class MeasureEquivalenceToMeasureEquivalenceDao : EntityToDaoBase<MeasureEquivalence, MeasureEquivalenceDao>
   {
      protected override void ContinueEntityToDao(IMappingExpression<MeasureEquivalence, MeasureEquivalenceDao> mappingExpression)
      {
         mappingExpression
            .ForMember(d => d.MeasureFrom, c => c.MapFrom(e => e.From.Measure))
            .ForMember(d => d.IngredientFrom, c => c.MapFrom(e => e.From.Ingredient))
            .ForMember(d => d.MeasureTo, c => c.MapFrom(e => e.To.Measure))
            .ForMember(d => d.IngredientTo, c => c.MapFrom(e => e.To.Ingredient));
      }

      protected override void ContinueDaoToEntity(IMappingExpression<MeasureEquivalenceDao, MeasureEquivalence> mappingExpression)
      {
         mappingExpression.ConstructUsing((dao, context) =>
            new MeasureEquivalence(
               dao.Id,
               context.Mapper.Map<Guid?, IDistributableId>(dao.DistributedId),
               context.Mapper.Map<Guid?, IDistributableId>(dao.OwnedBy),
               new MeasureIngredient(context.Mapper.Map<MeasureDao, Measure>(dao.MeasureFrom), context.Mapper.Map<Guid?, IDistributableId>(dao.IngredientFrom)),
               new MeasureIngredient(context.Mapper.Map<MeasureDao, Measure>(dao.MeasureTo), context.Mapper.Map<Guid?, IDistributableId>(dao.IngredientTo)),
               dao.Factor
            ));
      }
   }
}
