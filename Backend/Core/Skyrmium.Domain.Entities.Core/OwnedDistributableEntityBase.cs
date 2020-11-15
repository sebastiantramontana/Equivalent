using Skyrmium.Domain.Entities.Contracts;
using System;

namespace Skyrmium.Domain.Entities.Core
{
   public abstract class OwnedDistributableEntityBase : DistributableEntityBase, IOwnedEntity
   {
      protected OwnedDistributableEntityBase(IDistributableId distributedId, IDistributableId ownedBy)
         : base(distributedId)
      {
         OwnedBy = ownedBy;
      }

      public IDistributableId OwnedBy { get; }
   }
}
