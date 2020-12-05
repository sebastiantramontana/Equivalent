using Skyrmium.Domain.Contracts;
using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Domain.Implementations.Entities
{
   public abstract class DistributableEntityBase : EntityBase, IDistributableEntity
   {
      protected DistributableEntityBase(long id, IDistributableId distributedId)
         : base(id)
      {
         this.DistributedId = distributedId;
      }

      public IDistributableId DistributedId { get; }

      public bool Equals(IDistributableEntity? other)
      {
         return other is not null && this.DistributedId.Equals(other.DistributedId);
      }

      public override bool Equals(object? obj)
      {
         return Equals(obj as IDistributableEntity);
      }

      public override int GetHashCode()
      {
         return this.DistributedId.GetHashCode();
      }

      public static bool operator ==(DistributableEntityBase? e1, DistributableEntityBase? e2)
      {
         return e1?.Equals(e2) ?? false;
      }

      public static bool operator !=(DistributableEntityBase? e1, DistributableEntityBase? e2)
      {
         return !(e1 == e2);
      }
   }
}
