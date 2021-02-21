using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Contracts.Queryables;

namespace Skyrmium.Domain.Contracts.Repositories
{
   public interface IRepository<TEntity> where TEntity : class, IEntity
   {
      IQueryableEntity<TEntity> Query();
      TEntity GetById(long id);
      TEntity GetByDistributedId(IDistributableId distributedId);
      void Add(TEntity entity);
      void Update(TEntity entity);
      void Remove(TEntity entity);

   }
}
