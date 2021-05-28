using Skyrmium.Domain.Implementations.Entities;
using System;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities
{
   public class OrderedMeasureEquivalence : EntityBase
   {
      public OrderedMeasureEquivalence(Guid id, int order, MeasureEquivalence measureEquivalence, bool invertEquivalence)
         : base(id)
      {
         this.Order = order;
         this.MeasureEquivalence = measureEquivalence;
         this.InvertEquivalence = invertEquivalence;
      }

      public int Order { get; }
      public MeasureEquivalence MeasureEquivalence { get; }
      public bool InvertEquivalence { get; }
   }
}
