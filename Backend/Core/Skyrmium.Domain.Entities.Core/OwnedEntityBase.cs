using Skyrmium.Domain.Entities.Contracts;

namespace Skyrmium.Domain.Entities.Core
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
