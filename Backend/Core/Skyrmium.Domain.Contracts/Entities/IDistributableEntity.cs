using System;

namespace Skyrmium.Domain.Contracts.Entities
{
   public interface IDistributableEntity : IEntity, IEquatable<IDistributableEntity>
   {
      IDistributableId DistributedId { get; }
   }
}
