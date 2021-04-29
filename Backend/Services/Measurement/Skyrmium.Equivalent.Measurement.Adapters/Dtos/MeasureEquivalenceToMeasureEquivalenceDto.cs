using Skyrmium.Adapters.Contracts;
using Skyrmium.Adapters.Implementations.EntitiesToDtos;
using Skyrmium.Equivalent.Measurement.Api.Dtos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   public class MeasureEquivalenceToMeasureEquivalenceDto : OwnedEntityToDtoBase<MeasureEquivalence, MeasureEquivalenceDto>
   {
      private readonly IAdapter<Measure, MeasureDto> _measureAdapter;

      public MeasureEquivalenceToMeasureEquivalenceDto(IAdapter<Measure, MeasureDto> measureAdapter)
      {
         _measureAdapter = measureAdapter;
      }

      public override MeasureEquivalence Map(MeasureEquivalenceDto dto)
      {
         return new MeasureEquivalence(
            default,
            dto.DistributedId,
            dto.OwnedBy,
            new MeasureIngredient(_measureAdapter.Map(dto.MeasureFrom), dto.IngredientFrom),
            new MeasureIngredient(_measureAdapter.Map(dto.MeasureTo), dto.IngredientTo),
            dto.Factor);
      }

      protected override MeasureEquivalenceDto ContinueOwnedEntityToDto(MeasureEquivalence entity, MeasureEquivalenceDto dto)
      {
         return new MeasureEquivalenceDto
         {
            MeasureFrom = _measureAdapter.Map(entity.From.Measure),
            IngredientFrom = entity.From.Ingredient,
            MeasureTo = _measureAdapter.Map(entity.To.Measure),
            IngredientTo = entity.To.Ingredient
         };
      }
   }
}
