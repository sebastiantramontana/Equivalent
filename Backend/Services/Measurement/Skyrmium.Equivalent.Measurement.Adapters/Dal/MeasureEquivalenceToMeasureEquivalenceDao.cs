﻿using AutoMapper;
using Skyrmium.Adapters.Implementations.EntitiesToDaos;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Domain.Contracts;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   internal class MeasureEquivalenceToMeasureEquivalenceDao : OwnedEntityToOwnedDaoBase<MeasureEquivalence, MeasureEquivalenceDao>
   {
      protected override void ContinueWithOwnedEntity(IMappingExpression<MeasureEquivalence, MeasureEquivalenceDao> mappingExpression)
      {
         mappingExpression
            .ForMember(d => d.MeasureFrom, c => c.MapFrom(e => e.From.Measure))
            .ForMember(d => d.IngredientFrom, c => c.MapFrom(e => e.From.Ingredient))
            .ForMember(d => d.MeasureTo, c => c.MapFrom(e => e.To.Measure))
            .ForMember(d => d.IngredientTo, c => c.MapFrom(e => e.To.Ingredient))
            .ForMember(d => d.Factor, c => c.MapFrom(e => e.Factor));
      }

      protected override void ContinueWithOwnedDao(IMappingExpression<MeasureEquivalenceDao, MeasureEquivalence> mappingExpression)
      {
         mappingExpression
            .ForMember(e => e.From.Measure, c => c.MapFrom(d => d.MeasureFrom))
            .ForMember(e => e.From.Ingredient, c => c.MapFrom(d => d.IngredientFrom))
            .ForMember(e => e.To.Measure, c => c.MapFrom(d => d.MeasureTo))
            .ForMember(e => e.To.Ingredient, c => c.MapFrom(d => d.IngredientTo))
            .ForMember(e => e.Factor, c => c.MapFrom(d => d.Factor));
      }
   }
}
