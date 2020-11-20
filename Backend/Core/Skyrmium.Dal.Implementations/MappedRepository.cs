using Microsoft.EntityFrameworkCore;
using Skyrmium.Dal.Contracts;
using Skyrmium.Domain.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Skyrmium.Dal.Implementations
{
   public class MappedRepository<TEntity, TDao> : IMappedRepository<TEntity, TDao>
      where TEntity : IEntity
      where TDao : class, IDao
   {
      private readonly DbContext _dbContext;
      private readonly IDalAdapter<TEntity, TDao> _adapter;

      public MappedRepository(DbContext dbContext, IDalAdapter<TEntity, TDao> adapter)
      {
         _dbContext = dbContext;
         _adapter = adapter;
      }

      public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> condition)
      {
         var daos = _dbContext
            .Set<TDao>()
            .Where(_adapter.MapCondition(condition))
            .ToList();

         return daos.Select(dao => _adapter.Map(dao));
      }

      public IEnumerable<TEntity> GetAll()
      {
         var daos = _dbContext
            .Set<TDao>()
            .ToList();

         return daos.Select(dao => _adapter.Map(dao));
      }

      public TEntity GetById(long id)
      {
         var dao = _dbContext
            .Set<TDao>()
            .SingleOrDefault(dao => dao.Id == id)
            ?? throw new ObjectNotFoundException();

         return _adapter.Map(dao);
      }

      public TEntity GetByDistributedId(IDistributableId distributedId)
      {
         var dao = _dbContext
            .Set<TDao>()
            .SingleOrDefault(dao => dao.DistributedId == distributedId.Value)
            ?? throw new ObjectNotFoundException();

         return _adapter.Map(dao);
      }

      public void Add(TEntity entity)
      {
         var dao = _adapter.Map(entity);
         _dbContext.Set<TDao>().Add(dao);
      }

      public void Update(TEntity entity)
      {
         var dao = _adapter.Map(entity);
         _dbContext.Set<TDao>().Update(dao);
      }

      public void Remove(TEntity entity)
      {
         var dao = _adapter.Map(entity);
         _dbContext.Set<TDao>().Remove(dao);
      }
   }
}
