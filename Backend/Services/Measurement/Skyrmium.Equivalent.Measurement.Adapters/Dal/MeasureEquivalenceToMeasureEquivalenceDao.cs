using AutoMapper;
using Skyrmium.Adapters.Implementations.EntitiesToDaos;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   internal class MeasureEquivalenceToMeasureEquivalenceDao : OwnedEntityToOwnedDaoBase<MeasureEquivalence, MeasureEquivalenceDao>
   {
      protected override void ContinueWithOwnedEntity(IMappingExpression<MeasureEquivalence, MeasureEquivalenceDao> mappingExpression)
      {
         mappingExpression.ForMember(d => d.MeasureFrom, c => c.MapFrom(e => e.From.Measure));
         mappingExpression.ForMember(d => d.IngredientFrom, c => c.MapFrom(e => e.From.Ingredient));
         mappingExpression.ForMember(d => d.MeasureTo, c => c.MapFrom(e => e.To.Measure));
         mappingExpression.ForMember(d => d.IngredientTo, c => c.MapFrom(e => e.To.Ingredient));
         mappingExpression.ForMember(d => d.Factor, c => c.MapFrom(e => e.Factor));
      }

      protected override void ContinueWithOwnedDao(IMappingExpression<MeasureEquivalenceDao, MeasureEquivalence> mappingExpression)
      {
         mappingExpression.ForMember(e => e.From.Measure, c => c.MapFrom(d => d.MeasureFrom));
         mappingExpression.ForMember(e => e.From.Ingredient, c => c.MapFrom(d => d.IngredientFrom));
         mappingExpression.ForMember(e => e.To.Measure, c => c.MapFrom(d => d.MeasureTo));
         mappingExpression.ForMember(e => e.To.Ingredient, c => c.MapFrom(d => d.IngredientTo));
         mappingExpression.ForMember(e => e.Factor, c => c.MapFrom(d => d.Factor));
      }
   }
}
