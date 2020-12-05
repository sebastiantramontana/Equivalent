using Skyrmium.Domain.Contracts;
using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Domain.Implementations.Entities
{
   public abstract class OwnedDistributableEntityBase : DistributableEntityBase, IOwnedDistributableEntity
   {
      protected OwnedDistributableEntityBase(long id, IDistributableId distributedId, IDistributableId ownedBy)
         : base(id, distributedId)
      {
         OwnedBy = ownedBy;
      }

      public IDistributableId OwnedBy { get; }
   }
}
