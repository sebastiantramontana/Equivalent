using Skyrmium.Domain.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skyrmium.Domain.Services.Contracts
{
   public interface ICrudService<TEntity> where TEntity : IEntity
   {
      Task<IEnumerable<TEntity>> GetAll();
      Task<TEntity> GetById(Guid id);
      Task<TEntity> Create(TEntity entity);
      Task<IEnumerable<TEntity>> Create(IEnumerable<TEntity> entities);
      Task Update(TEntity entity);
      Task Update(IEnumerable<TEntity> entity);
      Task Delete(Guid id);
      Task Delete(IEnumerable<Guid> ids);
   }
}
