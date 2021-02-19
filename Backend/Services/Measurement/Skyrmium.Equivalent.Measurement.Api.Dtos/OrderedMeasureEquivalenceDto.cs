namespace Skyrmium.Equivalent.Measurement.Api.Dtos
{
   public class OrderedMeasureEquivalenceDto
   {
      public int Order { get; set; }
      public MeasureEquivalenceDto MeasureEquivalence { get; set; } = new MeasureEquivalenceDto();
   }
}
