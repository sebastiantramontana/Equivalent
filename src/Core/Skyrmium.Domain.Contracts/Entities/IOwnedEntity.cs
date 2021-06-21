using System;

namespace Skyrmium.Domain.Contracts.Entities
{
   public interface IOwnedEntity : IEntity
   {
      Guid OwnedBy { get; }
   }
}
