using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Implementations.Entities;
using System;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities
{
   public class MeasureEquivalence : OwnedEntityBase
   {
      public MeasureEquivalence(long id, Guid distributedId, Guid ownedBy, MeasureIngredient from, MeasureIngredient to, double factor) : base(id, distributedId, ownedBy)
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
