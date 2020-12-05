using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Dal.Contracts.Queryables
{
   public interface IQueryableOwnedDistributableEntity<TEntity> : IQueryableDistributableEntity<TEntity>, IQueryableOwnedEntity<TEntity>
      where TEntity : IOwnedDistributableEntity
   {
   }
}
