using Skyrmium.Domain.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Skyrmium.Domain.Contracts.Queryables
{
   public interface IQueryableEntity<TEntity> where TEntity : IEntity
   {
      TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
      IQueryableEntity<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
      IQueryable<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> selector);
      IEnumerable<TEntity> ToEnumerable();
   }
}
