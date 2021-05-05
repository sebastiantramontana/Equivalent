using Microsoft.AspNetCore.Mvc;
using Skyrmium.Api.Implementations;
using Skyrmium.Equivalent.Measurement.Api.Dtos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts;
using Skyrmium.Infrastructure.Contracts;

namespace Skyrmium.Equivalent.Measurement.Api.Controllers
{
   [Route("api/v1/[controller]")]
   [ApiController]
   public class ConversionController : OwnedCrudApiControllerBase<IConversionService, Conversion, ConversionDto>
   {
      public ConversionController(IConversionService conversioneService, IMapper<Conversion, ConversionDto> mapper)
         : base(conversioneService, mapper)
      {
      }
   }
}
