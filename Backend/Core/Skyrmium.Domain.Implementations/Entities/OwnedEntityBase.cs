using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Domain.Implementations.Entities
{
   public abstract class OwnedEntityBase : EntityBase, IOwnedEntity
   {
      protected OwnedEntityBase(long id, IDistributableId distributedId, IDistributableId ownedBy)
         : base(id, distributedId)
      {
         OwnedBy = ownedBy;
      }

      public IDistributableId OwnedBy { get; }
   }
}
