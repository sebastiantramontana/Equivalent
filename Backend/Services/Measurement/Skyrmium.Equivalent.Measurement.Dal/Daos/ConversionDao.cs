using Skyrmium.Dal.Implementations.Daos;
using System;
using System.Linq;

namespace Skyrmium.Equivalent.Measurement.Dal.Daos
{
   public class ConversionDao : OwnedDaoBase
   {
      public string Name { get; set; } = string.Empty;
      public IQueryable<OrderedMeasureEquivalenceDao> Equivalences { get; set; } = Array.Empty<OrderedMeasureEquivalenceDao>().AsQueryable();
   }
}
