using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Domain.Contracts.Queryables
{
   public interface IQueryableDistributableEntity<TEntity> : IQueryableEntity<TEntity> where TEntity : IDistributableEntity
   {
   }
}
