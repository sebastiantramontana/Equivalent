using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Contracts.Queryables;
using System;
using System.Threading.Tasks;

namespace Skyrmium.Domain.Contracts.Repositories
{
   public interface IRepository<TEntity> where TEntity : class, IEntity
   {
      IQueryableEntity<TEntity> Query();
      Task<TEntity> GetByIdAsync(long id);
      Task<TEntity> GetByDistributedIdAsync(Guid distributedId);
      void Add(TEntity entity);
      void Update(TEntity entity);
      void Remove(TEntity entity);

   }
}
