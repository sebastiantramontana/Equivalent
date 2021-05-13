using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Services.Contracts;
using Skyrmium.Domain.Services.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skyrmium.Domain.Services.Implementations
{
   public abstract class CrudServiceBase<TRepository, TEntity> : ICrudService<TEntity>
      where TEntity : class, IEntity
      where TRepository : IRepository<TEntity>
   {
      protected CrudServiceBase(TRepository repository)
      {
         this.Repository = repository;
      }

      protected TRepository Repository { get; }

      public Task<TEntity> Add(TEntity entity)
      {
         return this.Repository.Add(entity);
      }

      public Task<IEnumerable<TEntity>> Add(IEnumerable<TEntity> entities)
      {
         return this.Repository.Add(entities);
      }

      public Task<IEnumerable<TEntity>> GetAllAsync()
      {
         return this.Repository.GetAllAsync();
      }

      public Task<TEntity> GetByIdAsync(long id)
      {
         return this.Repository.GetByIdAsync(id);
      }

      public Task<TEntity> GetByDistributedIdAsync(Guid distributableId)
      {
         return this.Repository.GetByDistributedIdAsync(distributableId);
      }

      public Task Remove(Guid distributedId)
      {
         return this.Repository.Remove(distributedId);
      }

      public void Update(TEntity entity)
      {
         this.Repository.Update(entity);
      }
   }
}
