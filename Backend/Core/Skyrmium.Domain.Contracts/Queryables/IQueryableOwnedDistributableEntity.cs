using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Domain.Contracts.Queryables
{
   public interface IQueryableOwnedDistributableEntity<TEntity> : IQueryableDistributableEntity<TEntity>, IQueryableOwnedEntity<TEntity>
      where TEntity : IOwnedDistributableEntity
   {
   }
}
