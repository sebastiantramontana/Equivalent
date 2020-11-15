using Skyrmium.Domain.Entities.Contracts;

namespace Skyrmium.Domain.Entities.Core
{
   public abstract class EntityBase : IEntity
   {
      public long Id { get; set; }
   }
}
