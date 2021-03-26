using Microsoft.AspNetCore.Mvc;
using Skyrmium.Adapters.Contracts;
using Skyrmium.Api.Implementations;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Equivalent.Measurement.Api.Dtos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts;
using System;
using System.Collections.Generic;

namespace Skyrmium.Equivalent.Measurement.Api.Controllers
{
   [ApiController]
   [Route("api/v1/[controller]")]
   public class MeasuresController : CrudApiControllerBase<Measure, MeasureDto>
   {
      public MeasuresController(IMeasureService measureService, IAdapter<Measure, MeasureDto> adapter, IAdapter<IDistributableId, Guid> adapterDistributable)
         : base(measureService, adapter, adapterDistributable)
      {
      }
   }
}
