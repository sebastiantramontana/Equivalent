using Skyrmium.Api.Implementations;
using System;
using System.Collections.Generic;

namespace Skyrmium.Equivalent.Measurement.Api.Dtos
{
   public class ConversionDto : OwnedDtoBase
   {
      public string Name { get; set; } = string.Empty;
      public IEnumerable<OrderedMeasureEquivalenceDto> Equivalences { get; set; } = Array.Empty<OrderedMeasureEquivalenceDto>();

   }
}
