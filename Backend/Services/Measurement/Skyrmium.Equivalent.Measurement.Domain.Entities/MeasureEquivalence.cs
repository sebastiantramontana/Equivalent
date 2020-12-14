using Skyrmium.Domain.Contracts;
using Skyrmium.Domain.Implementations.Entities;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities
{
   public class MeasureEquivalence : OwnedEntityBase
   {
      public MeasureEquivalence(long id, IDistributableId ownedBy, MeasureIngredient from, MeasureIngredient to) : base(id, ownedBy)
      {
         this.From = from;
         this.To = to;
      }

      public MeasureIngredient From { get; }
      public MeasureIngredient To { get; }
      public double Factor { get; set; }
   }
}
