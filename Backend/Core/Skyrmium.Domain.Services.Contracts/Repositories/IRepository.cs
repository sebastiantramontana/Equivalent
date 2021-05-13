using Skyrmium.Domain.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skyrmium.Domain.Services.Contracts.Repositories
{
   public interface IRepository<TEntity> where TEntity : class, IEntity
   {
      Task<IEnumerable<TEntity>> GetAllAsync();
      Task<TEntity> GetByIdAsync(long id);
      Task<TEntity> GetByDistributedIdAsync(Guid id);
      Task<TEntity> Add(TEntity entity);
      Task<IEnumerable<TEntity>> Add(IEnumerable<TEntity> entities);
      void Update(TEntity entity);
      Task Remove(Guid distributedId);

   }
}
