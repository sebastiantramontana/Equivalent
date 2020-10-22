using System;

namespace Skyrmium.DomainModel.Entities.Contracts
{
   public interface IDistributableEntity : IEntity, IEquatable<IDistributableEntity>
   {
      Guid Guid { get; }
   }
}
