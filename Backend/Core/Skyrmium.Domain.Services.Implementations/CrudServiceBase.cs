using Skyrmium.Dal.Contracts;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Services.Contracts;
using System.Collections.Generic;

namespace Skyrmium.Domain.Services.Implementations
{
   public abstract class CrudServiceBase<TRepository, TEntity> : ICrudService<TEntity>
      where TEntity : IEntity
      where TRepository : IRepository<TEntity>
   {
      protected CrudServiceBase(TRepository repository)
      {
         this.Repository = repository;
      }

      protected TRepository Repository { get; }

      public void Add(TEntity entity)
      {
         this.Repository.Add(entity);
      }

      public IEnumerable<TEntity> Get()
      {
         return this.Repository.Query().ToEnumerable();
      }

      public TEntity GetById(long id)
      {
         return this.Repository.GetById(id);
      }

      public void Remove(TEntity entity)
      {
         this.Repository.Remove(entity);
      }

      public void Update(TEntity entity)
      {
         this.Repository.Update(entity);
      }
   }
}
