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
   [Route("api/v1/[controller]")]
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
      public async Task<IEnumerable<TDto>> Get()
      {
         var entities = await this.Service.GetAll();
         return this.Mapper.Map(entities);
      }

      [HttpGet("{id}")]
      public async Task<TDto> GetById(Guid id)
      {
         var entity = await this.Service.GetById(id);
         return this.Mapper.Map(entity);
      }

      [HttpPost]
      public async Task<TDto> Create([FromBody] TDto dto)
      {
         var entity = this.Mapper.Map(dto);
         entity = await this.Service.Create(entity);
         return this.Mapper.Map(entity);
      }

      [HttpPost("batch")]
      public async Task<IEnumerable<TDto>> Create([FromBody] IEnumerable<TDto> dtos)
      {
         var entities = this.Mapper.Map(dtos);
         entities = await this.Service.Create(entities);
         return this.Mapper.Map(entities);
      }

      // PUT api/<Controller>
      [HttpPut]
      public Task Update([FromBody] TDto dto)
      {
         var entity = this.Mapper.Map(dto);
         return this.Service.Update(entity);
      }

      [HttpPut("batch")]
      public Task Update([FromBody] IEnumerable<TDto> dtos)
      {
         var entities = this.Mapper.Map(dtos);
         return this.Service.Update(entities);
      }

      // DELETE api/<Controller>/5
      [HttpDelete("{id}")]
      public Task Delete(Guid id)
      {
         return this.Service.Delete(id);
      }

      [HttpDelete("batch")]
      public Task Delete([FromBody] IEnumerable<Guid> ids)
      {
         return this.Service.Delete(ids);
      }
   }
}
