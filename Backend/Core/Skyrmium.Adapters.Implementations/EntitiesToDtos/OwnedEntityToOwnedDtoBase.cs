using AutoMapper;
using Skyrmium.Api.Contracts;
using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Adapters.Implementations.EntitiesToDtos
{
   public abstract class OwnedEntityToOwnedDtoBase<TEntity, TDto> : EntityToDtoBase<TEntity, TDto>
      where TEntity : IOwnedEntity
      where TDto : IOwnedDto
   {
      protected OwnedEntityToOwnedDtoBase() { }

      protected override void ContinueWithEntity(IMappingExpression<TEntity, TDto> mappingExpression)
      {
         mappingExpression.ForMember(d => d.OwnedBy, cfg => cfg.MapFrom(e => e.OwnedBy.Value));

         ContinueWithOwnedEntity(mappingExpression);
      }

      protected override void ContinueWithDto(IMappingExpression<TDto, TEntity> mappingExpression)
      {
         mappingExpression.ForMember(e => e.OwnedBy, cfg => cfg.MapFrom(d => d.OwnedBy));

         ContinueWithOwnedDto(mappingExpression);
      }

      protected abstract void ContinueWithOwnedEntity(IMappingExpression<TEntity, TDto> mappingExpression);
      protected abstract void ContinueWithOwnedDto(IMappingExpression<TDto, TEntity> mappingExpression);
   }
}
