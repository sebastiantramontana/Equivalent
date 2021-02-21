using Microsoft.AspNetCore.Mvc;
using Skyrmium.Adapters.Contracts;
using Skyrmium.Api.Contracts;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Services.Contracts;
using System;
using System.Collections.Generic;

namespace Skyrmium.Api.Implementations
{
   [ApiController]
   public abstract class CrudApiControllerBase<TEntity, TDto> : ControllerBase
      where TEntity : class, IEntity
      where TDto : class, IDto
   {
      private readonly ICrudService<TEntity> _crudService;
      private readonly IAdapter<IDistributableId, Guid> _adapterDistributable;
      private readonly IAdapter<TEntity, TDto> _adapterEntity;

      protected CrudApiControllerBase(ICrudService<TEntity> crudService, IAdapter<TEntity, TDto> adapterEntity, IAdapter<IDistributableId, Guid> adapterDistributable)
      {
         _crudService = crudService;
         _adapterDistributable = adapterDistributable;
         _adapterEntity = adapterEntity;
      }

      [HttpGet]
      public IEnumerable<TDto> Get()
      {
         var entities = _crudService.Get();
         return _adapterEntity.Map(entities);
      }

      // GET api/<MeasureEquivalencesController>/5
      [HttpGet("{id}")]
      public TDto Get(Guid distributedId)
      {
         var distributedIdEntity = _adapterDistributable.Map(distributedId);
         var entity = _crudService.GetByDistributedId(distributedIdEntity);
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
