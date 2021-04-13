using AutoMapper;
using Skyrmium.Dal.Contracts.Daos;
using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Adapters.Implementations.EntitiesToDaos
{
   public abstract class EntityToDaoBase<TEntity, TDao> : Profile
      where TEntity : class, IEntity
      where TDao : class, IDao
   {
      protected EntityToDaoBase()
      {
         var mappingEntity = CreateMap<TEntity, TDao>()
            .ForMember(d => d.Id, cfg => cfg.MapFrom(e => e.Id))
            .ForMember(d => d.DistributedId, cfg => cfg.MapFrom(e => e.DistributedId));

         var mappingDao = CreateMap<TDao, TEntity>()
            .ForMember(e => e.Id, cfg => cfg.MapFrom(d => d.Id))
            .ForMember(e => e.DistributedId, cfg => cfg.MapFrom(d => d.DistributedId));


         ContinueEntityToDao(mappingEntity);
         ContinueDaoToEntity(mappingDao);
      }

      protected abstract void ContinueEntityToDao(IMappingExpression<TEntity, TDao> mappingExpression);
      protected abstract void ContinueDaoToEntity(IMappingExpression<TDao, TEntity> mappingExpression);
   }
}
