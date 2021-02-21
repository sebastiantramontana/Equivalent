using Skyrmium.Dal.Implementations.Daos;
using System;
using System.Collections.Generic;

namespace Skyrmium.Equivalent.Measurement.Dal.Daos
{
   public class MeasureEquivalenceDao : OwnedDaoBase
   {
      public MeasureDao MeasureFrom { get; set; } = new MeasureDao();
      public MeasureDao MeasureTo { get; set; } = new MeasureDao();
      public Guid? IngredientFrom { get; set; }
      public Guid? IngredientTo { get; set; }
      public double Factor { get; set; }

      public IEnumerable<OrderedMeasureEquivalenceDao> OrderedMeasureEquivalences { get; set; } = Array.Empty<OrderedMeasureEquivalenceDao>();
   }
}
