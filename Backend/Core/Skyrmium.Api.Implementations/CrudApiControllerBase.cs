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
   [ApiController]
   public abstract class CrudApiControllerBase<TService, TEntity, TDto> : ControllerBase
      where TService : ICrudService<TEntity>
      where TEntity : class, IEntity
      where TDto : class, IDto
   {
      protected CrudApiControllerBase(TService service, IMapper<TEntity, TDto> mapperEntity)
      {
         Service = service;
         Mapper = mapperEntity;
      }

      protected TService Service { get; }
      protected IMapper<TEntity, TDto> Mapper { get; }

      [HttpGet]
      public async Task<IEnumerable<TDto>> GetAsync()
      {
         var entities = await this.Service.GetAllAsync();
         return this.Mapper.Map(entities);
      }

      // GET api/<MeasureEquivalencesController>/5
      [HttpGet("{distributedId}")]
      public async Task<TDto> GetByDistributedAsync(Guid distributedId)
      {
         var entity = await Service.GetByDistributedIdAsync(distributedId);
         return this.Mapper.Map(entity);
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
