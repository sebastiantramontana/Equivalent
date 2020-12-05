using Skyrmium.Domain.Contracts;
using Skyrmium.Domain.Contracts.Entities;
using System.Collections.Generic;

namespace Skyrmium.Domain.Services.Contracts
{
   public interface IOwnedCrudService<TEntity> : ICrudService<TEntity>
      where TEntity : IOwnedEntity
   {
      IEnumerable<TEntity> GetByOwned(IDistributableId ownedBy);
   }
}
