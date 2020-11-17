using System;

namespace Skyrmium.Domain.Entities.Contracts
{
   public interface IEntity : IEquatable<IEntity>
   {
      long Id { get; }
   }
}
