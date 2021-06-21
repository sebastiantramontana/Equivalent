using Skyrmium.Api.Contracts;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Infrastructure.Contracts;

namespace Skyrmium.Api.Implementations.EntityMapping
{
   public abstract class EntityToDtoBase<TEntity, TDto> : MapperBase<TEntity, TDto>
      where TEntity : class, IEntity
      where TDto : class, IDto, new()
   {
      public sealed override TDto Map(TEntity entity)
      {
         var dto = new TDto { Id = entity.Id };

         return ContinueEntityToDto(entity, dto);
      }

      protected abstract TDto ContinueEntityToDto(TEntity entity, TDto dto);
   }
}
