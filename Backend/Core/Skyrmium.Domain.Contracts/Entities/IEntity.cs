using System;

namespace Skyrmium.Domain.Contracts.Entities
{
   public interface IEntity : IEquatable<IEntity>
   {
      long Id { get; }
      IDistributableId DistributedId { get; }
   }
}
