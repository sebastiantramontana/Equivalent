using AutoMapper;
using Skyrmium.Dal.Contracts.Daos;
using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Adapters.Implementations.EntitiesToDaos
{
   //TODO: NO ES NECESARIA ESTA CLASE: ELIMINAR!!!
   public abstract class OwnedEntityToOwnedDaoBase<TEntity, TDao> : EntityToDaoBase<TEntity, TDao>
      where TEntity : IOwnedEntity
      where TDao : IOwnedDao
   {
      protected OwnedEntityToOwnedDaoBase() { }

      protected override void ContinueEntityToDao(IMappingExpression<TEntity, TDao> mappingExpression)
      {
         ContinueOwnedEntityToOwnedDao(mappingExpression);
      }

      protected override void ContinueDaoToEntity(IMappingExpression<TDao, TEntity> mappingExpression)
      {
         ContinueWithOwnedDaoToOwnedEntity(mappingExpression);
      }

      protected abstract void ContinueOwnedEntityToOwnedDao(IMappingExpression<TEntity, TDao> mappingExpression);
      protected abstract void ContinueWithOwnedDaoToOwnedEntity(IMappingExpression<TDao, TEntity> mappingExpression);
   }
}
