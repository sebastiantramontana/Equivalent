using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Dal.Contracts.Queryables
{
   public interface IQueryableOwnedEntity<TEntity> : IQueryableEntity<TEntity> where TEntity : IOwnedEntity
   {
   }
}
