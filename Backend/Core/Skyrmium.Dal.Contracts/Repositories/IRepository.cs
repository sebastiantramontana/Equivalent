using Skyrmium.Dal.Contracts.Queryables;
using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Dal.Contracts
{
   public interface IRepository<TEntity> where TEntity : IEntity
   {
      IQueryableEntity<TEntity> Query();
      TEntity GetById(long id);
      void Add(TEntity entity);
      void Update(TEntity entity);
      void Remove(TEntity entity);

   }
}
