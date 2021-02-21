using AutoMapper;
using Skyrmium.Dal.Contracts.Daos;
using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Adapters.Implementations.EntitiesToDaos
{
   public abstract class OwnedEntityToOwnedDaoBase<TEntity, TDao> : EntityToDaoBase<TEntity, TDao>
      where TEntity : IOwnedEntity
      where TDao : IOwnedDao
   {
      protected OwnedEntityToOwnedDaoBase() { }

      protected override void ContinueEntityToDao(IMappingExpression<TEntity, TDao> mappingExpression)
      {
         //mappingExpression.ForMember(d => d.OwnedBy, cfg => cfg.MapFrom(e => e.OwnedBy.Value));

         ContinueOwnedEntityToOwnedDao(mappingExpression);
      }

      protected override void ContinueDaoToEntity(IMappingExpression<TDao, TEntity> mappingExpression)
      {
         //mappingExpression.ForMember(e => e.OwnedBy, cfg => cfg.MapFrom(d => d.OwnedBy));

         ContinueWithOwnedDao(mappingExpression);
      }

      protected abstract void ContinueOwnedEntityToOwnedDao(IMappingExpression<TEntity, TDao> mappingExpression);
      protected abstract void ContinueWithOwnedDao(IMappingExpression<TDao, TEntity> mappingExpression);
   }
}
