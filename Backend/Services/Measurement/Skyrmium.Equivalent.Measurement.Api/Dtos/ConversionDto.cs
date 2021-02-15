using Skyrmium.Api.Implementations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Skyrmium.Equivalent.Measurement.Api.Dtos
{
   public class ConversionDto : OwnedDtoBase
   {
      public string Name { get; set; } = string.Empty;
      public IEnumerable<OrderedMeasureEquivalenceDto> Equivalences { get; set; } = Array.Empty<OrderedMeasureEquivalenceDao>().AsQueryable();

   }
}
