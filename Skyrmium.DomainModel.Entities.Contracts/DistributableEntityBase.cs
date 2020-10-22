using System;

namespace Skyrmium.DomainModel.Entities.Contracts
{
   public abstract class DistributableEntityBase : EntityBase, IDistributableEntity
   {
      public Guid Guid { get; set; }

      public bool Equals(IDistributableEntity other)
      {
         return other is not null && this.Guid.Equals(other.Guid);
      }
      public override bool Equals(object obj)
      {
         return Equals(obj as IDistributableEntity);
      }
      public override int GetHashCode()
      {
         return this.Guid.GetHashCode();
      }
      public static bool operator ==(DistributableEntityBase e1, DistributableEntityBase e2)
      {
         return e1 is not null && e2 is not null && e1.Equals(e2);
      }
      public static bool operator !=(DistributableEntityBase e1, DistributableEntityBase e2)
      {
         return e1 is null || e2 is null || !e1.Equals(e2);
      }
      public static bool operator ==(DistributableEntityBase e1, IDistributableEntity e2)
      {
         return e1 is not null && e2 is not null && e1.Equals(e2);
      }
      public static bool operator !=(DistributableEntityBase e1, IDistributableEntity e2)
      {
         return e1 is null || e2 is null || !e1.Equals(e2);
      }

      public static bool operator ==(IDistributableEntity e1, DistributableEntityBase e2)
      {
         return e1 is not null && e2 is not null && e1.Equals(e2);
      }
      public static bool operator !=(IDistributableEntity e1, DistributableEntityBase e2)
      {
         return e1 is null || e2 is null || !e1.Equals(e2);
      }
   }
}
