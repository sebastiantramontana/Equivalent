using Skyrmium.Dal.Contracts.Daos;
using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Adapters.Implementations.EntitiesToDaos
{
   public abstract class OwnedEntityToDaoBase<TEntity, TDao> : EntityToDaoBase<TEntity, TDao>
      where TEntity : class, IOwnedEntity
      where TDao : class, IOwnedDao, new()
   {
      protected sealed override TDao ContinueEntityToDao(TEntity entity, TDao dao)
      {
         dao.OwnedBy = entity.OwnedBy;

         return ContinueOwnedEntityToDao(entity, dao);
      }

      protected abstract TDao ContinueOwnedEntityToDao(TEntity entity, TDao dao);
   }
}
