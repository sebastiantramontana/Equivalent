using Skyrmium.Dal.Contracts.Daos;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Infrastructure.Contracts;

namespace Skyrmium.Dal.Implementations.EntityMapping
{
   public abstract class EntityToDaoBase<TEntity, TDao> : MapperBase<TEntity, TDao>
      where TEntity : class, IEntity
      where TDao : class, IDao, new()
   {
      public sealed override TDao Map(TEntity entity)
      {
         var dao = new TDao
         {
            Id = entity.Id
         };

         return ContinueEntityToDao(entity, dao);
      }

      protected abstract TDao ContinueEntityToDao(TEntity entity, TDao dao);
   }
}
