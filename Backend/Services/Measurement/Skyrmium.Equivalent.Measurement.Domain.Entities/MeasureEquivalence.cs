using Skyrmium.Domain.Entities.Contracts;
using Skyrmium.Domain.Entities.Core;
using System;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities
{
   public class MeasureEquivalence : OwnedDistributableEntityBase
   {
      public MeasureEquivalence(IDistributableId distributableId, IDistributableId ownedBy) : base(distributableId, ownedBy)
      {
      }

      public Measure From { get; set; }
      public Measure To { get; set; }
      public IDistributableId Ingredient { get; set; }
      public double Factor { get; set; }
   }
}
