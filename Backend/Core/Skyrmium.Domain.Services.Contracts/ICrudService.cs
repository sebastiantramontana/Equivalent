using Skyrmium.Domain.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skyrmium.Domain.Services.Contracts
{
   public interface ICrudService<TEntity> where TEntity : IEntity
   {
      Task<IEnumerable<TEntity>> GetAllAsync();
      Task<TEntity> GetByIdAsync(long id);
      Task<TEntity> GetByDistributedIdAsync(Guid distributableId);
      Task<TEntity> Add(TEntity entity);
      Task<IEnumerable<TEntity>> Add(IEnumerable<TEntity> entities);
      void Update(TEntity entity);
      Task Remove(Guid distributedId);
   }
}
