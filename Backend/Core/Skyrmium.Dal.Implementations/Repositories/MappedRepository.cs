using Microsoft.EntityFrameworkCore;
using Skyrmium.Dal.Contracts;
using Skyrmium.Dal.Contracts.Adapters;
using Skyrmium.Dal.Contracts.Daos;
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
      private protected IDalAdapter<TEntity, TDao> DalAdapter { get; }

      public MappedRepository(DbContext dbContext, IQueryableEntity<TEntity> queryableEntity, IDalAdapter<TEntity, TDao> dalAdapter)
      {
         this.DbContext = dbContext;
         this.QueryableEntity = queryableEntity;
         this.DalAdapter = dalAdapter;
      }

      public IQueryableEntity<TEntity> Query()
      {
         return this.QueryableEntity;
      }

      public TEntity GetById(long id)
      {
         var dao = this.QueryableEntity
            .SingleOrDefault(dao => dao.Id == id)
            ?? throw new ObjectNotFoundException();

         return dao;
      }

      public void Add(TEntity entity)
      {
         var dao = this.DalAdapter.Map(entity);
         this.DbContext.Set<TDao>().Add(dao);
      }

      public void Update(TEntity entity)
      {
         var dao = this.DalAdapter.Map(entity);
         this.DbContext.Set<TDao>().Update(dao);
      }

      public void Remove(TEntity entity)
      {
         var dao = this.DalAdapter.Map(entity);
         this.DbContext.Set<TDao>().Remove(dao);
      }
   }
}
