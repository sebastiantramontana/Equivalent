using Skyrmium.Domain.Contracts.Entities;
using System;

namespace Skyrmium.Domain.Implementations.Entities
{
   public abstract class EntityBase : IEntity
   {
      protected EntityBase(Guid id)
      {
         this.Id = id;
      }

      public Guid Id { get; }

      public bool Equals(IEntity? other)
      {
         return other is not null && this.Id.Equals(other.Id);
      }

      public override bool Equals(object? obj)
      {
         return Equals(obj as IEntity);
      }

      public override int GetHashCode()
      {
         return this.Id.GetHashCode();
      }

      public static bool operator ==(EntityBase? e1, EntityBase? e2)
      {
         return e1?.Equals(e2) ?? false;
      }

      public static bool operator !=(EntityBase? e1, EntityBase? e2)
      {
         return !(e1 == e2);
      }
   }
}
