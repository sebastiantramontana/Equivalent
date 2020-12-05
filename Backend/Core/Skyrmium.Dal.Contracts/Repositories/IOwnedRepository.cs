using Skyrmium.Dal.Contracts.Queryables;
using Skyrmium.Domain.Contracts;
using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Dal.Contracts.Repositories
{
   public interface IOwnedRepository<TEntity> : IRepository<TEntity> where TEntity : IOwnedEntity
   {
      IQueryableEntity<TEntity> GetByOwned(IDistributableId ownedBy);
   }
}
