using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Contracts.Repositories;
using Skyrmium.Domain.Services.Contracts;
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

      public void Add(TEntity entity)
      {
         this.Repository.Add(entity);
      }

      public Task<IEnumerable<TEntity>> GetAsync()
      {
         return this.Repository.Query().ToEnumerableAsync();
      }

      public TEntity GetById(long id)
      {
         return this.Repository.GetById(id);
      }

      public TEntity GetByDistributedId(IDistributableId distributableId)
      {
         return this.Repository.GetByDistributedId(distributableId);
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
