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

      // GET api/<Controller>/5
      [HttpGet("{distributedId}")]
      public async Task<TDto> GetByDistributedIdAsync(Guid distributedId)
      {
         var entity = await this.Service.GetByDistributedIdAsync(distributedId);
         return this.Mapper.Map(entity);
      }

      // POST api/<Controller>
      [HttpPost]
      public async Task<TDto> Post([FromBody] TDto dto)
      {
         var entity = this.Mapper.Map(dto);
         entity = await this.Service.Add(entity);
         return this.Mapper.Map(entity);
      }

      // PUT api/<Controller>/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody] TDto dto)
      {

      }

      // DELETE api/<Controller>/5
      [HttpDelete("{distributedId}")]
      public Task Delete(Guid distributedId)
      {
         return this.Service.Remove(distributedId);
      }
   }
}
