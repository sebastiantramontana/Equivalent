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

      public Task<TEntity> GetByIdAsync(long id)
      {
         return this.Repository.GetByIdAsync(id);
      }

      public Task<TEntity> GetByDistributedIdAsync(IDistributableId distributableId)
      {
         return this.Repository.GetByDistributedIdAsync(distributableId);
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
