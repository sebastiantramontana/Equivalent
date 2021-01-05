using Microsoft.EntityFrameworkCore;
using Skyrmium.Adapters.Contracts;
using Skyrmium.Dal.Contracts;
using Skyrmium.Dal.Contracts.Daos;
using Skyrmium.Domain.Contracts;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Contracts.Queryables;
using Skyrmium.Domain.Contracts.Repositories;

namespace Skyrmium.Dal.Implementations.Repositories
{
   public class MappedRepository<TEntity, TDao> : IRepository<TEntity>
      where TEntity : IEntity
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

      public TEntity GetById(long id)
      {
         var entity = this.QueryableEntity
            .SingleOrDefault(e => e.Id == id)
            ?? throw new ObjectNotFoundException();

         return entity;
      }

      public TEntity GetByDistributedId(IDistributableId distributedId)
      {
         var entity = this.QueryableEntity
           .SingleOrDefault(e => e.DistributedId == distributedId)
           ?? throw new ObjectNotFoundException();

         return entity;
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
   }
}
