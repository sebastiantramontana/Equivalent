using Skyrmium.Domain.Entities.Contracts;
using System;
using System.Linq.Expressions;

namespace Skyrmium.Dal.Contracts
{
   public interface IAdapter<TEntity, TDao>
      where TEntity : IEntity
      where TDao : IDao
   {
      TDao Map(TEntity entity);
      TEntity Map(IDao dao);
      Expression<Func<IDao, bool>> MapCondition(Expression<Func<TEntity, bool>> condition);
   }
}
