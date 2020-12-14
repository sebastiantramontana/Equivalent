using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Domain.Contracts.Queryables
{
   public interface IQueryableOwnedEntity<TEntity> : IQueryableEntity<TEntity> where TEntity : IOwnedEntity
   {
   }
}
