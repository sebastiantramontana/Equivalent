using AutoMapper;
using Skyrmium.Adapters.Implementations.EntitiesToDtos;
using Skyrmium.Equivalent.Measurement.Api.Dtos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   internal class MeasureEquivalenceToMeasureEquivalenceDto : OwnedEntityToDtoBase<MeasureEquivalence, MeasureEquivalenceDto>
   {
      protected override void ContinueWithEntity(IMappingExpression<MeasureEquivalence, MeasureEquivalenceDto> mappingExpression)
      {
         mappingExpression
            .ForMember(d => d.MeasureFrom, c => c.MapFrom(e => e.From.Measure))
            .ForMember(d => d.IngredientFrom, c => c.MapFrom(e => e.From.Ingredient))
            .ForMember(d => d.MeasureTo, c => c.MapFrom(e => e.To.Measure))
            .ForMember(d => d.IngredientTo, c => c.MapFrom(e => e.To.Ingredient))
            .ForMember(d => d.Factor, c => c.MapFrom(e => e.Factor));
      }

      protected override void ContinueWithDto(IMappingExpression<MeasureEquivalenceDto, MeasureEquivalence> mappingExpression)
      {
         mappingExpression
            .ForPath(e => e.From.Measure, c => c.MapFrom(d => d.MeasureFrom))
            .ForPath(e => e.From.Ingredient, c => c.MapFrom(d => d.IngredientFrom))
            .ForPath(e => e.To.Measure, c => c.MapFrom(d => d.MeasureTo))
            .ForPath(e => e.To.Ingredient, c => c.MapFrom(d => d.IngredientTo))
            .ForMember(e => e.Factor, c => c.MapFrom(d => d.Factor));
      }
   }
}
