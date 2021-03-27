using Skyrmium.Domain.Contracts.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skyrmium.Domain.Services.Contracts
{
   public interface IOwnedCrudService<TEntity> : ICrudService<TEntity>
      where TEntity : IOwnedEntity
   {
      Task<IEnumerable<TEntity>> GetByOwned(IDistributableId ownedBy);
   }
}
