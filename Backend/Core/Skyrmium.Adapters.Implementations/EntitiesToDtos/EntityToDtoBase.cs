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

         ContinueEntityToDto(mappingEntity);
         ContinueDtoToEntity(mappingDao);
      }

      protected abstract void ContinueEntityToDto(IMappingExpression<TEntity, TDto> mappingExpression);
      protected abstract void ContinueDtoToEntity(IMappingExpression<TDto, TEntity> mappingExpression);
   }
}
