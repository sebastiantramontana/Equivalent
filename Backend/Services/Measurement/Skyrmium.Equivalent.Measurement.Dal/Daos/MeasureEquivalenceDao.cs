using Skyrmium.Dal.Contracts.Daos;
using Skyrmium.Domain.Contracts;
using System;

namespace Skyrmium.Equivalent.Measurement.Dal.Daos
{
   public class MeasureEquivalenceDao : IOwnedDao
   {
      public long Id { get; set; }
      public MeasureDao MeasureFrom { get; set; } = new MeasureDao();
      public MeasureDao MeasureTo { get; set; } = new MeasureDao();
      public Guid IngredientFrom { get; set; }
      public Guid IngredientTo { get; set; }
      public double Factor { get; set; }
      public IDistributableId? OwnedBy { get; set; }
   }
}
