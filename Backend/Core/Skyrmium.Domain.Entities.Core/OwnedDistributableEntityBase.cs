using Skyrmium.Domain.Entities.Contracts;
using System;

namespace Skyrmium.Domain.Entities.Core
{
   public abstract class OwnedDistributableEntityBase : DistributableEntityBase, IOwnedEntity
   {
      protected OwnedDistributableEntityBase(long id, IDistributableId distributedId, IDistributableId ownedBy)
         : base(id, distributedId)
      {
         OwnedBy = ownedBy;
      }

      public IDistributableId OwnedBy { get; }
   }
}
