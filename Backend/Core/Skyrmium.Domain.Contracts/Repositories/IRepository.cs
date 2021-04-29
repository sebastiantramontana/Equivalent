using Skyrmium.Domain.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skyrmium.Domain.Contracts.Repositories
{
   public interface IRepository<TEntity> where TEntity : class, IEntity
   {
      Task<IEnumerable<TEntity>> GetAllAsync();
      Task<TEntity> GetByIdAsync(long id);
      Task<TEntity> GetByDistributedIdAsync(Guid distributedId);
      void Add(TEntity entity);
      void Update(TEntity entity);
      void Remove(TEntity entity);

   }
}
