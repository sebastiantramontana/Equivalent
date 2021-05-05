using Skyrmium.Api.Implementations;

namespace Skyrmium.Equivalent.Measurement.Api.Dtos
{
   public class OrderedMeasureEquivalenceDto : DtoBase
   {
      public int Order { get; set; }
      public MeasureEquivalenceDto MeasureEquivalence { get; set; } = new MeasureEquivalenceDto();
   }
}
