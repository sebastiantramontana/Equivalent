using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Skyrmium.Equivalent.Measurement.Api.Controllers
{
   [ApiController]
   [Route("[controller]")]
   public class MeasureController : ControllerBase
   {
      private readonly ILogger<MeasureController> _logger;

      public MeasureController(ILogger<MeasureController> logger)
      {
         _logger = logger;
      }

      [HttpGet]
      public IEnumerable<Measure> Get()
      {
         return Array.Empty<Measure>();
      }
   }
}
