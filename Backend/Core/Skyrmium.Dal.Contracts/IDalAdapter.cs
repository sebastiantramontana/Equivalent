using Skyrmium.Domain.Entities.Contracts;
using Skyrmium.Infrastructure.Contracts;
using System;
using System.Linq.Expressions;

namespace Skyrmium.Dal.Contracts
{
   public interface IDalAdapter<TEntity, TDao> : IAdapter<TEntity, TDao>
      where TEntity : IEntity
      where TDao : IDao
   {
      Expression<Func<TDao, bool>> MapCondition(Expression<Func<TEntity, bool>> condition);
   }
}
