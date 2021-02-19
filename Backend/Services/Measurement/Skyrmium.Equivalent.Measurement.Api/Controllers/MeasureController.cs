using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts;
using System.Collections.Generic;

namespace Skyrmium.Equivalent.Measurement.Api.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class MeasureController : ControllerBase
   {
      private readonly IMeasureService _measureService;
      private readonly ILogger<MeasureController> _logger;

      public MeasureController(IMeasureService measureService, ILogger<MeasureController> logger)
      {
         _measureService = measureService;
         _logger = logger;
      }

      [HttpGet]
      public IEnumerable<Measure> Get()
      {
         return _measureService.Get();
      }
   }
}
