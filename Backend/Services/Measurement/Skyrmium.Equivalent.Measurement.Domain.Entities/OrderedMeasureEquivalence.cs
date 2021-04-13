using Skyrmium.Domain.Implementations.Entities;
using System;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities
{
   public class OrderedMeasureEquivalence : EntityBase
   {
      public OrderedMeasureEquivalence(int id, Guid distributedId, int order, MeasureEquivalence measureEquivalence)
         : base(id, distributedId)
      {
         this.Order = order;
         this.MeasureEquivalence = measureEquivalence;
      }

      public int Order { get; }
      public MeasureEquivalence MeasureEquivalence { get; }
   }
}
