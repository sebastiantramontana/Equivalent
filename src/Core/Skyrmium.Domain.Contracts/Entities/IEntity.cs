using System;

namespace Skyrmium.Domain.Contracts.Entities
{
   public interface IEntity : IEquatable<IEntity>
   {
      Guid Id { get; }
   }
}
