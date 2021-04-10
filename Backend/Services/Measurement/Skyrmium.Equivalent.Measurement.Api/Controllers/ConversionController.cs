using Microsoft.AspNetCore.Mvc;
using Skyrmium.Adapters.Contracts;
using Skyrmium.Api.Implementations;
using Skyrmium.Equivalent.Measurement.Api.Dtos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Skyrmium.Equivalent.Measurement.Api.Controllers
{
   [Route("api/v1/[controller]")]
   [ApiController]
   public class ConversionController : OwnedCrudApiControllerBase<Conversion, ConversionDto>
   {
      public ConversionController(IConversionService conversioneService, IAdapter<Conversion, ConversionDto> adapter)
         : base(conversioneService, adapter)
      {
      }
   }
}
