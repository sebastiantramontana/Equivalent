using Microsoft.AspNetCore.Mvc;
using Skyrmium.Adapters.Contracts;
using Skyrmium.Api.Contracts;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skyrmium.Api.Implementations
{
   [ApiController]
   public abstract class OwnedCrudApiControllerBase<TService, TEntity, TDto> : CrudApiControllerBase<TService, TEntity, TDto>
      where TService : IOwnedCrudService<TEntity>
      where TEntity : class, IOwnedEntity
      where TDto : class, IOwnedDto
   {
      protected OwnedCrudApiControllerBase(TService service, IAdapter<TEntity, TDto> adapterEntity)
         : base(service, adapterEntity)
      {
      }

      // GET api/<MeasureEquivalencesController>/5
      [HttpGet("owned/{ownedById}")]
      public async Task<IEnumerable<TDto>> GetByOwnedAsync(Guid ownedById)
      {
         var entity = await this.Service.GetByOwned(ownedById);
         return this.Adapter.Map(entity);
      }
   }
}
