using Skyrmium.Api.Implementations;

namespace Skyrmium.Equivalent.Measurement.Api.Dtos
{
   public class MeasureDto : OwnedDtoBase
   {
      public string FullName { get; set; } = string.Empty;

      public string ShortName { get; set; } = string.Empty;
   }
}
