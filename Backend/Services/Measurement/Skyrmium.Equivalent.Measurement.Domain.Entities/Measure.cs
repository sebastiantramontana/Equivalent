using Skyrmium.Domain.Implementations.Entities;
using System;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities
{
   public class Measure : OwnedEntityBase
   {
      public Measure(Guid id, Guid ownedBy, string fullName, string shortName) : base(id, ownedBy)
      {
         this.FullName = fullName;
         this.ShortName = shortName;
      }

      public string FullName { get; } = string.Empty;
      public string ShortName { get; } = string.Empty;

      public override string ToString()
      {
         return ShortName ?? FullName;
      }
   }
}
