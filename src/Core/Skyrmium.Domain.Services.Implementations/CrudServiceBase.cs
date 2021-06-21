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

      public Task<TEntity> Create(TEntity entity)
      {
         return this.Repository.Create(entity);
      }

      public Task<IEnumerable<TEntity>> Create(IEnumerable<TEntity> entities)
      {
         return this.Repository.Create(entities);
      }

      public Task Update(TEntity entity)
      {
         return this.Repository.Update(entity);
      }
      public Task Update(IEnumerable<TEntity> entities)
      {
         return this.Repository.Update(entities);
      }

      public Task Delete(Guid id)
      {
         return this.Repository.Delete(id);
      }

      public Task Delete(IEnumerable<Guid> ids)
      {
         return this.Repository.Delete(ids);
      }
   }
}
