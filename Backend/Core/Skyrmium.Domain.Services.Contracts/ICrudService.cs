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
      void Add(TEntity entity);
      void Update(TEntity entity);
      void Remove(TEntity entity);
   }
}
