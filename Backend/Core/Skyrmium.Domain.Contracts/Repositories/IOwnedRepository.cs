using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Contracts.Queryables;

namespace Skyrmium.Domain.Contracts.Repositories
{
   public interface IOwnedRepository<TEntity> : IRepository<TEntity> where TEntity : IOwnedEntity
   {
      IQueryableEntity<TEntity> GetByOwned(IDistributableId ownedBy);
   }
}
