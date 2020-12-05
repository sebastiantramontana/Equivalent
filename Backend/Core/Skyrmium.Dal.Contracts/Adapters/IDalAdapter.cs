using Skyrmium.Dal.Contracts.Daos;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Infrastructure.Contracts;
using System;
using System.Linq.Expressions;

namespace Skyrmium.Dal.Contracts.Adapters
{
   public interface IDalAdapter<TEntity, TDao> : IAdapter<TEntity, TDao>
      where TEntity : IEntity
      where TDao : IDao
   {
      Expression<Func<TDao, T>> MapExpression<T>(Expression<Func<TEntity, T>> condition);
   }
}
