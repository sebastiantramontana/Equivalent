using Skyrmium.Domain.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skyrmium.Domain.Services.Contracts
{
   public interface ICrudService<TEntity> where TEntity : IEntity
   {
      Task<IEnumerable<TEntity>> GetAllAsync();
      Task<TEntity> GetByIdAsync(Guid id);
      Task<TEntity> Add(TEntity entity);
      Task<IEnumerable<TEntity>> Add(IEnumerable<TEntity> entities);
      Task Update(TEntity entity);
      Task Update(IEnumerable<TEntity> entity);
      Task Remove(Guid id);
      Task Remove(IEnumerable<Guid> ids);
   }
}
