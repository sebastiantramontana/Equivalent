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

      protected override void ContinueWithEntity(IMappingExpression<TEntity, TDao> mappingExpression)
      {
         mappingExpression.ForMember(d => d.OwnedBy, cfg => cfg.MapFrom(e => e.OwnedBy.Value));

         ContinueWithOwnedEntity(mappingExpression);
      }

      protected override void ContinueWithDao(IMappingExpression<TDao, TEntity> mappingExpression)
      {
         mappingExpression.ForMember(e => e.OwnedBy, cfg => cfg.MapFrom(d => d.OwnedBy));

         ContinueWithOwnedDao(mappingExpression);
      }

      protected abstract void ContinueWithOwnedEntity(IMappingExpression<TEntity, TDao> mappingExpression);
      protected abstract void ContinueWithOwnedDao(IMappingExpression<TDao, TEntity> mappingExpression);
   }
}
