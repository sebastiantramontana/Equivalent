using Skyrmium.Domain.Contracts.Entities;
using System;

namespace Skyrmium.Domain.Implementations.Entities
{
   public abstract class OwnedEntityBase : EntityBase, IOwnedEntity
   {
      protected OwnedEntityBase(long id, Guid distributedId, Guid ownedBy)
         : base(id, distributedId)
      {
         OwnedBy = ownedBy;
      }

      public Guid OwnedBy { get; }
   }
}
