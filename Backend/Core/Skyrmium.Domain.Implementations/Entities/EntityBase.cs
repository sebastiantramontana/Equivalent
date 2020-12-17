﻿using Skyrmium.Domain.Contracts;
using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Domain.Implementations.Entities
{
   public abstract class EntityBase : IEntity
   {
      protected EntityBase(long id, IDistributableId distributedId)
      {
         this.Id = id;
         this.DistributedId = distributedId;
      }

      public long Id { get; }
      public IDistributableId DistributedId { get; }

      public bool Equals(IEntity? other)
      {
         return other is not null && this.DistributedId.Equals(other.DistributedId);
      }

      public override bool Equals(object? obj)
      {
         return Equals(obj as IEntity);
      }

      public override int GetHashCode()
      {
         return this.DistributedId.GetHashCode();
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
