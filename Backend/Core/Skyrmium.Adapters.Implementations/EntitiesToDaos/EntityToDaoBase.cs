using Skyrmium.Dal.Contracts.Daos;
using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Adapters.Implementations.EntitiesToDaos
{
   public abstract class EntityToDaoBase<TEntity, TDao> : AdapterBase<TEntity, TDao>
      where TEntity : class, IEntity
      where TDao : class, IDao, new()
   {
      public sealed override TDao Map(TEntity entity)
      {
         var dao = new TDao
         {
            Id = entity.Id,
            DistributedId = entity.DistributedId
         };

         return ContinueEntityToDao(entity, dao);
      }

      protected abstract TDao ContinueEntityToDao(TEntity entity, TDao dao);
   }
}
