using Skyrmium.Api.Implementations.EntityMapping;
using Skyrmium.Equivalent.Measurement.Api.Dtos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Infrastructure.Contracts;

namespace Skyrmium.Equivalent.Measurement.Api.EntityMapping
{
   public class MeasureEquivalenceToMeasureEquivalenceDto : OwnedEntityToDtoBase<MeasureEquivalence, MeasureEquivalenceDto>
   {
      private readonly IMapper<Measure, MeasureDto> _measureMapper;

      public MeasureEquivalenceToMeasureEquivalenceDto(IMapper<Measure, MeasureDto> measureMapper)
      {
         _measureMapper = measureMapper;
      }

      public override MeasureEquivalence Map(MeasureEquivalenceDto dto)
      {
         return new MeasureEquivalence(
            dto.Id,
            dto.OwnedBy,
            new MeasureIngredient(_measureMapper.Map(dto.MeasureFrom), dto.IngredientFrom),
            new MeasureIngredient(_measureMapper.Map(dto.MeasureTo), dto.IngredientTo),
            dto.Factor);
      }

      protected override MeasureEquivalenceDto ContinueOwnedEntityToDto(MeasureEquivalence entity, MeasureEquivalenceDto dto)
      {
         dto.MeasureFrom = _measureMapper.Map(entity.From.Measure);
         dto.IngredientFrom = entity.From.Ingredient;
         dto.MeasureTo = _measureMapper.Map(entity.To.Measure);
         dto.IngredientTo = entity.To.Ingredient;
         dto.Factor = entity.Factor;

         return dto;
      }
   }
}
