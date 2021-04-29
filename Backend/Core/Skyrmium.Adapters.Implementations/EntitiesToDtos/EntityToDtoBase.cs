using Skyrmium.Api.Contracts;
using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Adapters.Implementations.EntitiesToDtos
{
   public abstract class EntityToDtoBase<TEntity, TDto> : AdapterBase<TEntity, TDto>
      where TEntity : class, IEntity
      where TDto : class, IDto, new()
   {
      public sealed override TDto Map(TEntity entity)
      {
         var dto = new TDto { DistributedId = entity.DistributedId };

         return ContinueEntityToDto(entity, dto);
      }

      protected abstract TDto ContinueEntityToDto(TEntity entity, TDto dto);
   }
}
