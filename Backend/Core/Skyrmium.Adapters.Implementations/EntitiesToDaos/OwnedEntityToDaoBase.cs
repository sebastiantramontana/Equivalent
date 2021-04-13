using AutoMapper;
using Skyrmium.Dal.Contracts.Daos;
using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Adapters.Implementations.EntitiesToDaos
{
   public abstract class OwnedEntityToDaoBase<TEntity, TDao> : EntityToDaoBase<TEntity, TDao>
      where TEntity : class, IOwnedEntity
      where TDao : class, IOwnedDao
   {
      protected sealed override void ContinueDaoToEntity(IMappingExpression<TDao, TEntity> mappingExpression)
      {
         mappingExpression.ForMember(e => e.OwnedBy, cfg => cfg.MapFrom(d => d.OwnedBy));

         ContinueOwnedDaoToEntity(mappingExpression);
      }

      protected sealed override void ContinueEntityToDao(IMappingExpression<TEntity, TDao> mappingExpression)
      {
         mappingExpression.ForMember(d => d.OwnedBy, cfg => cfg.MapFrom(e => e.OwnedBy));

         ContinueOwnedEntityToDao(mappingExpression);
      }

      protected abstract void ContinueOwnedEntityToDao(IMappingExpression<TEntity, TDao> mappingExpression);
      protected abstract void ContinueOwnedDaoToEntity(IMappingExpression<TDao, TEntity> mappingExpression);
   }
}
