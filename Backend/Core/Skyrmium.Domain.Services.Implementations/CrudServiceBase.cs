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

      public Task<IEnumerable<TEntity>> GetAll()
      {
         return this.Repository.GetAll();
      }

      public Task<TEntity> GetById(Guid id)
      {
         return this.Repository.GetById(id);
      }

      public Task<TEntity> Add(TEntity entity)
      {
         return this.Repository.Add(entity);
      }

      public Task<IEnumerable<TEntity>> Add(IEnumerable<TEntity> entities)
      {
         return this.Repository.Add(entities);
      }

      public Task Update(TEntity entity)
      {
         return this.Repository.Update(entity);
      }
      public Task Update(IEnumerable<TEntity> entities)
      {
         return this.Repository.Update(entities);
      }

      public Task Remove(Guid id)
      {
         return this.Repository.Remove(id);
      }

      public Task Remove(IEnumerable<Guid> ids)
      {
         return this.Repository.Remove(ids);
      }
   }
}
