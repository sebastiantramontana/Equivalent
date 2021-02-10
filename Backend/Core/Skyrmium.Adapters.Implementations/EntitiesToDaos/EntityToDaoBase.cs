using AutoMapper;
using Skyrmium.Dal.Contracts.Daos;
using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Adapters.Implementations.EntitiesToDaos
{
   public abstract class EntityToDaoBase<TEntity, TDao> : Profile
      where TEntity : IEntity
      where TDao : IDao
   {
      protected EntityToDaoBase()
      {
         var mappingEntity = CreateMap<TEntity, TDao>(MemberList.None)
            .ForMember(d => d.Id, (x) => x.MapFrom((e) => e.Id))
            .ForMember(d => d.DistributedId, (x) => x.MapFrom((e) => e.DistributedId.Value));

         var mappingDao = CreateMap<TDao, TEntity>(MemberList.None)
            .ForMember(e => e.Id, (x) => x.MapFrom((e) => e.Id))
            .ForMember(e => e.DistributedId, (x) => x.MapFrom((d) => d.DistributedId));

         ContinueWithEntity(mappingEntity);
         ContinueWithDao(mappingDao);
      }

      protected abstract void ContinueWithEntity(IMappingExpression<TEntity, TDao> mappingExpression);
      protected abstract void ContinueWithDao(IMappingExpression<TDao, TEntity> mappingExpression);
   }
}
