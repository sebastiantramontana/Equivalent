using Skyrmium.Domain.Entities.Contracts;
using Skyrmium.Domain.Entities.Core;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities
{
   public class MeasureEquivalence : OwnedEntityBase
   {
      public MeasureEquivalence(long id, IDistributableId ownedBy, Measure measureFrom, Measure measureTo, IDistributableId ingredientFrom, IDistributableId ingredientTo) : base(id, ownedBy)
      {
         this.MeasureFrom = measureFrom;
         this.MeasureTo = measureTo;
         this.IngredientFrom = ingredientFrom;
         this.IngredientTo = ingredientTo;
      }

      public Measure MeasureFrom { get; }
      public Measure MeasureTo { get; }
      public IDistributableId IngredientFrom { get; }
      public IDistributableId IngredientTo { get; }
      public double Factor { get; set; }
   }
}
