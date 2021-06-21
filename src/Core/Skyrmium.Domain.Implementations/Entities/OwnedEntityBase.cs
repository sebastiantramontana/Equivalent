using Skyrmium.Domain.Contracts.Entities;
using System;

namespace Skyrmium.Domain.Implementations.Entities
{
   public abstract class OwnedEntityBase : EntityBase, IOwnedEntity
   {
      protected OwnedEntityBase(Guid id, Guid ownedBy)
         : base(id)
      {
         OwnedBy = ownedBy;
      }

      public Guid OwnedBy { get; }
   }
}
