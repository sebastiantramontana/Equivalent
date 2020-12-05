using Skyrmium.Domain.Contracts;
using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Domain.Implementations.Entities
{
   public abstract class OwnedEntityBase : EntityBase, IOwnedEntity
   {
      protected OwnedEntityBase(long id, IDistributableId ownedBy)
         : base(id)
      {
         OwnedBy = ownedBy;
      }

      public IDistributableId OwnedBy { get; }
   }
}
