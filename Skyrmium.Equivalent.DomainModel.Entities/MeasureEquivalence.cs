using Skyrmium.DomainModel.Entities.Contracts;

namespace Skyrmium.Equivalent.DomainModel.Entities
{
   public class MeasureEquivalence : EntityBase
   {
      public Measure From { get; set; }
      public Measure To { get; set; }
      public double Factor { get; set; }
      public IIngredient Ingredient { get; set; }
   }
}
