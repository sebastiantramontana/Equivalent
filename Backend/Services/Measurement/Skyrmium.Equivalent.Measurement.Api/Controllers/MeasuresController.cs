using Microsoft.AspNetCore.Mvc;
using Skyrmium.Adapters.Contracts;
using Skyrmium.Equivalent.Measurement.Api.Dtos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts;
using System.Collections.Generic;

namespace Skyrmium.Equivalent.Measurement.Api.Controllers
{
   [ApiController]
   [Route("api/v1/[controller]")]
   public class MeasuresController : ControllerBase
   {
      private readonly IMeasureService _measureService;
      private readonly IAdapter<Measure, MeasureDto> _adapter;

      public MeasuresController(IMeasureService measureService, IAdapter<Measure, MeasureDto> adapter)
      {
         _measureService = measureService;
         _adapter = adapter;
      }

      [HttpGet]
      public IEnumerable<MeasureDto> Get()
      {
         var entities = _measureService.Get();
         return _adapter.Map(entities);
      }
   }
}
