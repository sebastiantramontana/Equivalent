using Microsoft.AspNetCore.Mvc;
using Skyrmium.Api.Implementations;
using Skyrmium.Equivalent.Measurement.Api.Dtos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts;
using Skyrmium.Infrastructure.Contracts;

namespace Skyrmium.Equivalent.Measurement.Api.Controllers
{
   [ApiController]
   [Route("api/v1/[controller]")]
   public class MeasuresController : OwnedCrudApiControllerBase<IMeasureService, Measure, MeasureDto>
   {
      public MeasuresController(IMeasureService measureService, IMapper<Measure, MeasureDto> mapper)
         : base(measureService, mapper)
      {
      }
   }
}
