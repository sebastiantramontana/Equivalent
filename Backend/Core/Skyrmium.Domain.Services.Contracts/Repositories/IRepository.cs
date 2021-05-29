using Skyrmium.Domain.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skyrmium.Domain.Services.Contracts.Repositories
{
   public interface IRepository<TEntity> where TEntity : class, IEntity
   {
      Task<IEnumerable<TEntity>> GetAll();
      Task<TEntity> GetById(Guid id);
      Task<TEntity> Add(TEntity entity);
      Task<IEnumerable<TEntity>> Add(IEnumerable<TEntity> entities);
      Task Update(TEntity entity);
      Task Update(IEnumerable<TEntity> entities);
      Task Remove(Guid id);
      Task Remove(IEnumerable<Guid> ids);
   }
}
