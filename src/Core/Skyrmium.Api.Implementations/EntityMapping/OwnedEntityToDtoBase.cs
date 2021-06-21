using Skyrmium.Api.Contracts;
using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Api.Implementations.EntityMapping
{
   public abstract class OwnedEntityToDtoBase<TEntity, TDto> : EntityToDtoBase<TEntity, TDto>
      where TEntity : class, IOwnedEntity
      where TDto : class, IOwnedDto, new()
   {
      protected sealed override TDto ContinueEntityToDto(TEntity entity, TDto dto)
      {
         dto.OwnedBy = entity.OwnedBy;

         return ContinueOwnedEntityToDto(entity, dto);
      }
      protected abstract TDto ContinueOwnedEntityToDto(TEntity entity, TDto dto);
   }
}
