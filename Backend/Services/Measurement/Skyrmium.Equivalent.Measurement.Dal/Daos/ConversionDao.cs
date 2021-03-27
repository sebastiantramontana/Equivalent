using Skyrmium.Dal.Implementations.Daos;
using System;
using System.Collections.Generic;

namespace Skyrmium.Equivalent.Measurement.Dal.Daos
{
   public class ConversionDao : OwnedDaoBase
   {
      public string Name { get; set; } = string.Empty;
      public IEnumerable<OrderedMeasureEquivalenceDao> Equivalences { get; set; } = Array.Empty<OrderedMeasureEquivalenceDao>();
   }
}
