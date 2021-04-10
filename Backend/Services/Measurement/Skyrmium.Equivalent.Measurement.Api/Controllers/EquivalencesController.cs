using Microsoft.AspNetCore.Mvc;
using Skyrmium.Adapters.Contracts;
using Skyrmium.Api.Implementations;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Equivalent.Measurement.Api.Dtos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Skyrmium.Equivalent.Measurement.Api.Controllers
{
   [Route("api/v1/[controller]")]
   [ApiController]
   public class EquivalencesController : OwnedCrudApiControllerBase<MeasureEquivalence, MeasureEquivalenceDto>
   {
      public EquivalencesController(IEquivalenceService measureEquivalenceService, IAdapter<MeasureEquivalence, MeasureEquivalenceDto> adapter)
         : base(measureEquivalenceService, adapter)
      {
      }

      //double GetFactor(Measure from, Measure to);
      //double GetFactor(Measure from, Measure to, Guid ingredient);
      //double GetFactor(MeasureIngredient from, MeasureIngredient to);
   }
}
