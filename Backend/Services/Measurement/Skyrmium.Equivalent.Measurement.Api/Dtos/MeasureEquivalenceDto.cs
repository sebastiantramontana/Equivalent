using Skyrmium.Api.Implementations;
using System;

namespace Skyrmium.Equivalent.Measurement.Api.Dtos
{
   public class MeasureEquivalenceDto : OwnedDtoBase
   {
      public MeasureDto MeasureFrom { get; set; } = new MeasureDto();
      public MeasureDto MeasureTo { get; set; } = new MeasureDto();
      public Guid IngredientFrom { get; set; }
      public Guid IngredientTo { get; set; }
      public double Factor { get; set; }
   }
}
