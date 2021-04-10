using AutoMapper;
using Skyrmium.Api.Contracts;
using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Adapters.Implementations.EntitiesToDtos
{
   public abstract class OwnedEntityToDtoBase<TEntity, TDto> : EntityToDtoBase<TEntity, TDto>
      where TEntity : IOwnedEntity
      where TDto : IOwnedDto
   {
      protected OwnedEntityToDtoBase()
      {
      }

      protected override abstract void ContinueWithEntity(IMappingExpression<TEntity, TDto> mappingExpression);
      protected override abstract void ContinueWithDto(IMappingExpression<TDto, TEntity> mappingExpression);
   }
}
