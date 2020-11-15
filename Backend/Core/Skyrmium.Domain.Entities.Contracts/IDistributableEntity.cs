using System;

namespace Skyrmium.Domain.Entities.Contracts
{
   public interface IDistributableEntity : IEntity, IEquatable<IDistributableEntity>
   {
      IDistributableId DistributedId { get; }
   }
}
