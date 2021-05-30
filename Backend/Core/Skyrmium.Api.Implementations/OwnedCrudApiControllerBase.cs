using Microsoft.AspNetCore.Mvc;
using Skyrmium.Api.Contracts;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Services.Contracts;
using Skyrmium.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skyrmium.Api.Implementations
{
   public abstract class OwnedCrudApiControllerBase<TService, TEntity, TDto> : CrudApiControllerBase<TService, TEntity, TDto>
       where TService : IOwnedCrudService<TEntity>
       where TEntity : class, IOwnedEntity
       where TDto : class, IOwnedDto
   {
      protected OwnedCrudApiControllerBase(TService service, IMapper<TEntity, TDto> mapperEntity)
         : base(service, mapperEntity)
      {
      }

      // GET api/<MeasureEquivalencesController>/5
      [HttpGet("owned/{ownedById}")]
      public async Task<IEnumerable<TDto>> GetByOwned(Guid ownedById)
      {
         var entity = await this.Service.GetByOwned(ownedById);
         return this.Mapper.Map(entity);
      }
   }
}
