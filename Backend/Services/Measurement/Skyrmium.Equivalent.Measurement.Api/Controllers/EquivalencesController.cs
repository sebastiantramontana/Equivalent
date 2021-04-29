using Microsoft.AspNetCore.Mvc;
using Skyrmium.Adapters.Contracts;
using Skyrmium.Api.Implementations;
using Skyrmium.Equivalent.Measurement.Api.Dtos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts;
using System;
using System.Threading.Tasks;

namespace Skyrmium.Equivalent.Measurement.Api.Controllers
{
   [Route("api/v1/[controller]")]
   [ApiController]
   public class EquivalencesController : OwnedCrudApiControllerBase<IEquivalenceService, MeasureEquivalence, MeasureEquivalenceDto>
   {
      public EquivalencesController(IEquivalenceService measureEquivalenceService, IAdapter<MeasureEquivalence, MeasureEquivalenceDto> adapter)
         : base(measureEquivalenceService, adapter)
      {
      }

      [HttpGet("factor/{measureFrom}/{measureTo}")]
      public Task<double> GetFactor(Guid measureFrom, Guid measureTo)
      {
         return this.Service.GetFactor(measureFrom, measureTo);
      }

      [HttpGet("factor/{measureFrom}/{measureTo}/{ingredient}")]
      public Task<double> GetFactor(Guid measureFrom, Guid measureTo, Guid ingredient)
      {
         return this.Service.GetFactor(measureFrom, measureTo, ingredient);
      }

      [HttpGet("factor/{measureFrom}/{ingredientFrom}/{measureTo}/{ingredientTo}")]
      public Task<double> GetFactor(Guid measureFrom, Guid ingredientFrom, Guid measureTo, Guid ingredientTo)
      {
         return this.Service.GetFactor(measureFrom, ingredientFrom, measureTo, ingredientTo);
      }
   }
}
