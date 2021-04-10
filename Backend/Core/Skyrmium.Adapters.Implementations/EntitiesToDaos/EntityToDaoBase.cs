using AutoMapper;
using Skyrmium.Dal.Contracts.Daos;
using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Adapters.Implementations.EntitiesToDaos
{
   public abstract class EntityToDaoBase<TEntity, TDao> : Profile
      where TEntity : IOwnedEntity
      where TDao : IOwnedDao
   {
      protected EntityToDaoBase()
      {
         var mappingEntity = CreateMap<TEntity, TDao>();
         var mappingDao = CreateMap<TDao, TEntity>();

         ContinueEntityToDao(mappingEntity);
         ContinueDaoToEntity(mappingDao);
      }

      protected abstract void ContinueEntityToDao(IMappingExpression<TEntity, TDao> mappingExpression);
      protected abstract void ContinueDaoToEntity(IMappingExpression<TDao, TEntity> mappingExpression);
   }
}
