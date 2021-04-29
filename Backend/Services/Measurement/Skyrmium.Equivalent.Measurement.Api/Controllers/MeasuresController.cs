﻿using Microsoft.AspNetCore.Mvc;
using Skyrmium.Adapters.Contracts;
using Skyrmium.Api.Implementations;
using Skyrmium.Equivalent.Measurement.Api.Dtos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts;

namespace Skyrmium.Equivalent.Measurement.Api.Controllers
{
   [ApiController]
   [Route("api/v1/[controller]")]
   public class MeasuresController : OwnedCrudApiControllerBase<IMeasureService, Measure, MeasureDto>
   {
      public MeasuresController(IMeasureService measureService, IAdapter<Measure, MeasureDto> adapter)
         : base(measureService, adapter)
      {
      }
   }
}
