using Microsoft.EntityFrameworkCore;
using Skyrmium.Adapters.Contracts;
using Skyrmium.Dal.Contracts;
using Skyrmium.Dal.Contracts.Daos;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Skyrmium.Dal.Implementations.Repositories
{
   public class Repository<TEntity, TDao> : IRepository<TEntity>
      where TEntity : class, IEntity
      where TDao : class, IDao
   {
      protected DbContext DbContext { get; }
      protected IAdapter<TEntity, TDao> Adapter { get; }

      public Repository(DbContext dbContext, IAdapter<TEntity, TDao> adapter)
      {
         this.DbContext = dbContext;
         this.Adapter = adapter;
      }

      public async Task<IEnumerable<TEntity>> GetAllAsync()
      {
         var daos = await this.DbContext.Set<TDao>().ToListAsync();
         return this.Adapter.Map(daos);
      }

      public Task<TEntity> GetByIdAsync(long id)
      {
         return GetSingleEntityAsync(d => d.Id == id);
      }

      public Task<TEntity> GetByDistributedIdAsync(Guid distributedId)
      {
         return GetSingleEntityAsync(d => d.DistributedId == distributedId);
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
