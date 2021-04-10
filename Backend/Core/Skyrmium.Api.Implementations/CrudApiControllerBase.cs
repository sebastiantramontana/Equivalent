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
   public abstract class CrudApiControllerBase<TEntity, TDto> : ControllerBase
      where TEntity : class, IEntity
      where TDto : class, IDto
   {
      private readonly ICrudService<TEntity> _crudService;
      private readonly IAdapter<TEntity, TDto> _adapterEntity;

      protected CrudApiControllerBase(ICrudService<TEntity> crudService, IAdapter<TEntity, TDto> adapterEntity)
      {
         _crudService = crudService;
         _adapterEntity = adapterEntity;
      }

      [HttpGet]
      public async Task<IEnumerable<TDto>> GetAsync()
      {
         var entities = await _crudService.GetAsync();
         return _adapterEntity.Map(entities);
      }

      // GET api/<MeasureEquivalencesController>/5
      [HttpGet("{distributedId}")]
      public async Task<TDto> GetByDistributedAsync(Guid distributedId)
      {
         var entity = await _crudService.GetByDistributedIdAsync(distributedId);
         return _adapterEntity.Map(entity);
      }

      // POST api/<MeasureEquivalencesController>
      [HttpPost]
      public void Post([FromBody] string value)
      {
      }

      // PUT api/<MeasureEquivalencesController>/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody] string value)
      {
      }

      // DELETE api/<MeasureEquivalencesController>/5
      [HttpDelete("{id}")]
      public void Delete(int id)
      {
      }
   }
}
