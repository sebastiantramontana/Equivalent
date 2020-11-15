using Skyrmium.Domain.Entities.Contracts;

namespace Skyrmium.Domain.Entities.Core
{
   public abstract class DistributableEntityBase : EntityBase, IDistributableEntity
   {
      protected DistributableEntityBase(IDistributableId distributedId)
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
         return Equals(e1, e2);
      }

      public static bool operator !=(DistributableEntityBase? e1, DistributableEntityBase? e2)
      {
         return !Equals(e1, e2);
      }

      public static bool operator ==(DistributableEntityBase e1, IDistributableEntity e2)
      {
         return Equals(e1, e2);
      }

      public static bool operator !=(DistributableEntityBase e1, IDistributableEntity e2)
      {
         return !Equals(e1, e2);
      }

      public static bool operator ==(IDistributableEntity e1, DistributableEntityBase e2)
      {
         return Equals(e1, e2);
      }

      public static bool operator !=(IDistributableEntity e1, DistributableEntityBase e2)
      {
         return !Equals(e1, e2);
      }

      private static bool Equals(IDistributableEntity? e1, IDistributableEntity? e2)
      {
         return e1 is not null && e1.Equals(e2);
      }
   }
}
