using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Dal.Contracts.Queryables
{
   public interface IQueryableDistributableEntity<TEntity> : IQueryableEntity<TEntity> where TEntity : IDistributableEntity
   {
   }
}
