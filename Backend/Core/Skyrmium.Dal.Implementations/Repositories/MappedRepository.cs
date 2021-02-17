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

namespace Skyrmium.Dal.Implementations.Repositories
{
   internal class MappedRepository<TEntity, TDao> : IRepository<TEntity>
      where TEntity : IEntity
      where TDao : class, IDao
   {
      private protected DbContext DbContext { get; }
      private protected IQueryableEntity<TEntity> QueryableEntity { get; }
      private protected IAdapter<TEntity, TDao> Adapter { get; }

      internal MappedRepository(DbContext dbContext, IQueryableEntity<TEntity> queryableEntity, IAdapter<TEntity, TDao> adapter)
      {
         this.DbContext = dbContext;
         this.QueryableEntity = queryableEntity;
         this.Adapter = adapter;
      }

      public IQueryableEntity<TEntity> Query()
      {
         return this.QueryableEntity;
      }

      public TEntity GetById(long id)
      {
         return GetSingleEntity(d => d.Id == id);
      }

      public TEntity GetByDistributedId(IDistributableId distributedId)
      {
         var distributedIdValue = distributedId.Value;

         return GetSingleEntity(d => d.DistributedId == distributedIdValue);
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

      private TEntity GetSingleEntity(Expression<Func<TDao, bool>> expressionCondition)
      {
         var dao = this.DbContext
           .Set<TDao>()
           .SingleOrDefault(expressionCondition)
           ?? throw new DataObjectNotFoundException();

         var entity = this.Adapter.Map(dao);
         return entity;
      }
   }
}
