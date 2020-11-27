using Skyrmium.Dal.Contracts;
using System;

namespace Skyrmium.Equivalent.Measurement.Dal.Daos
{
   public class MeasureEquivalenceDao : IDao
   {
      public long Id { get; set; }
      public Guid DistributedId { get => Guid.Empty; set => _; }
      public MeasureDao MeasureFrom { get; set; } = new MeasureDao();
      public MeasureDao MeasureTo { get; set; } = new MeasureDao();
      public Guid IngredientFrom { get; set; }
      public Guid IngredientTo { get; set; }
      public double Factor { get; set; }
   }
}
