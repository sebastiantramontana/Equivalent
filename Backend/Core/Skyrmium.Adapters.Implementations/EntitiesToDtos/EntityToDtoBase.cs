using AutoMapper;
using Skyrmium.Api.Contracts;
using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Adapters.Implementations.EntitiesToDtos
{
   public abstract class EntityToDtoBase<TEntity, TDto> : Profile
      where TEntity : IEntity
      where TDto : IDto
   {
      protected EntityToDtoBase()
      {
         var mappingEntity = CreateMap<TEntity, TDto>(MemberList.None);
         var mappingDao = CreateMap<TDto, TEntity>(MemberList.None);

         ContinueWithEntity(mappingEntity);
         ContinueWithDto(mappingDao);
      }

      protected abstract void ContinueWithEntity(IMappingExpression<TEntity, TDto> mappingExpression);
      protected abstract void ContinueWithDto(IMappingExpression<TDto, TEntity> mappingExpression);
   }
}
