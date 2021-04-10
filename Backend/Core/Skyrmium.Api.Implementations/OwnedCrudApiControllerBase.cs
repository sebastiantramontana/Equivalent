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
   public abstract class OwnedCrudApiControllerBase<TEntity, TDto> : CrudApiControllerBase<TEntity, TDto>
      where TEntity : class, IOwnedEntity
      where TDto : class, IOwnedDto
   {
      private readonly IOwnedCrudService<TEntity> _crudService;
      private readonly IAdapter<IDistributableId, Guid> _adapterDistributable;
      private readonly IAdapter<TEntity, TDto> _adapterEntity;

      protected OwnedCrudApiControllerBase(IOwnedCrudService<TEntity> crudService, IAdapter<TEntity, TDto> adapterEntity, IAdapter<IDistributableId, Guid> adapterDistributable)
         : base(crudService, adapterEntity, adapterDistributable)
      {
         _crudService = crudService;
         _adapterDistributable = adapterDistributable;
         _adapterEntity = adapterEntity;
      }

      // GET api/<MeasureEquivalencesController>/5
      [HttpGet("owned/{ownedById}")]
      public async Task<IEnumerable<TDto>> GetByOwnedAsync(Guid ownedById)
      {
         var ownedByIdEntity = _adapterDistributable.Map(ownedById);
         var entity = await _crudService.GetByOwned(ownedByIdEntity);
         return _adapterEntity.Map(entity);
      }
   }
}
