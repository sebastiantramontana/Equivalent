using Skyrmium.Domain.Implementations.Entities;
using System;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities
{
   public class MeasureEquivalence : OwnedEntityBase
   {
      public MeasureEquivalence(Guid id, Guid ownedBy, MeasureIngredient from, MeasureIngredient to, double factor) : base(id, ownedBy)
      {
         this.From = from;
         this.To = to;
         this.Factor = factor;
      }

      public MeasureIngredient From { get; }
      public MeasureIngredient To { get; }
      public double Factor { get; }
   }
}
