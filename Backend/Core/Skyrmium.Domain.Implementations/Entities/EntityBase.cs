using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Domain.Implementations.Entities
{
   public abstract class EntityBase : IEntity
   {
      protected EntityBase(long id)
      {
         this.Id = id;
      }

      public long Id { get; }

      public override bool Equals(object? obj)
      {
         return Equals(obj as IEntity);
      }

      public bool Equals(IEntity? other)
      {
         return other is not null && this.Id == other.Id;
      }

      public override int GetHashCode()
      {
         return this.Id.GetHashCode();
      }

      public static bool operator ==(EntityBase? left, EntityBase? right)
      {
         return left?.Equals(right) ?? false;
      }

      public static bool operator !=(EntityBase? left, EntityBase? right)
      {
         return !(left == right);
      }
   }
}
