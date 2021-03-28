using Microsoft.EntityFrameworkCore;
using Skyrmium.Adapters.Contracts;
using Skyrmium.Dal.Contracts;
using Skyrmium.Dal.Contracts.Daos;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Contracts.Queryables;
using Skyrmium.Domain.Contracts.Repositories;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Skyrmium.Dal.Implementations.Repositories
{
   public class MappedRepository<TEntity, TDao> : IRepository<TEntity>
      where TEntity : class, IEntity
      where TDao : class, IDao
   {
      private protected DbContext DbContext { get; }
      private protected IQueryableEntity<TEntity> QueryableEntity { get; }
      private protected IAdapter<TEntity, TDao> Adapter { get; }

      public MappedRepository(DbContext dbContext, IQueryableEntity<TEntity> queryableEntity, IAdapter<TEntity, TDao> adapter)
      {
         this.DbContext = dbContext;
         this.QueryableEntity = queryableEntity;
         this.Adapter = adapter;
      }

      public IQueryableEntity<TEntity> Query()
      {
         return this.QueryableEntity;
      }

      public Task<TEntity> GetByIdAsync(long id)
      {
         return GetSingleEntityAsync(d => d.Id == id);
      }

      public Task<TEntity> GetByDistributedIdAsync(IDistributableId distributedId)
      {
         var distributedIdValue = distributedId.Value;

         return GetSingleEntityAsync(d => d.DistributedId == distributedIdValue);
      }

      public void Add(TEntity entity)
      {
         var dao = this.Adapter.Map(entity);
         this.DbContext.Set<TDao>().Add(dao);
      }

      public void Update(TEntity entity)
      {
         var dao = this.Adapter.Map(entity);
         this.DbContext.Set<TDao>().Update(dao);
      }

      public void Remove(TEntity entity)
      {
         var dao = this.Adapter.Map(entity);
         this.DbContext.Set<TDao>().Remove(dao);
      }

      private async Task<TEntity> GetSingleEntityAsync(Expression<Func<TDao, bool>> expressionCondition)
      {
         var dao = await this.DbContext
           .Set<TDao>()
           .SingleOrDefaultAsync(expressionCondition)
           ?? throw new DataObjectNotFoundException();

         var entity = this.Adapter.Map(dao);
         return entity;
      }
   }
}
