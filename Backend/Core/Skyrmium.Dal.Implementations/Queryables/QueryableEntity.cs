using Microsoft.EntityFrameworkCore;
using Skyrmium.Adapters.Contracts;
using Skyrmium.Dal.Contracts.Daos;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Contracts.Queryables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Skyrmium.Dal.Implementations.Queryables
{
   public class QueryableEntity<TEntity, TDao> : IQueryableEntity<TEntity>
      where TEntity : IEntity
      where TDao : class, IOwnedDao
   {
      private readonly IExpressionAdapter<TEntity, TDao> _expressionAdapter;
      private IQueryable<TDao> _queryable;

      public QueryableEntity(IExpressionAdapter<TEntity, TDao> expressionAdapter, DbContext dbContext)
      {
         _expressionAdapter = expressionAdapter;
         _queryable = dbContext.Set<TDao>();
      }

      public IQueryable<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> selector)
      {
         var newQueryable = _queryable.Select(_expressionAdapter.Map(selector));
         return newQueryable;
      }

      public TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
      {
         var dao = _queryable.SingleOrDefault(_expressionAdapter.Map(predicate));
         return dao is not null ? _expressionAdapter.Map(dao) : default;
      }

      public IQueryableEntity<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
      {
         _queryable = _queryable.Where(_expressionAdapter.Map(predicate));
         return this;
      }

      public async Task<IEnumerable<TEntity>> ToEnumerableAsync()
      {
         var daos = await _queryable.ToListAsync();
         return daos.Select(dao => _expressionAdapter.Map(dao));
      }
   }
}
