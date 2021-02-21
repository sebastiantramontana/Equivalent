using Microsoft.AspNetCore.Mvc;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Skyrmium.Equivalent.Measurement.Api.Controllers
{
   [Route("api/v1/[controller]")]
   [ApiController]
   public class EquivalencesController : ControllerBase
   {
      private readonly IEquivalenceService _measureEquivalenceService;

      public EquivalencesController(IEquivalenceService measureEquivalenceService)
      {
         _measureEquivalenceService = measureEquivalenceService;
      }

      // GET: api/<MeasureEquivalencesController>
      [HttpGet]
      public IEnumerable<string> Get()
      {
         return null; // _measureEquivalenceService.Get();
      }

      // GET api/<MeasureEquivalencesController>/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
         return "value";
      }

      // POST api/<MeasureEquivalencesController>
      [HttpPost]
      public void Post([FromBody] string value)
      {
      }

      // PUT api/<MeasureEquivalencesController>/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody] string value)
      {
      }

      // DELETE api/<MeasureEquivalencesController>/5
      [HttpDelete("{id}")]
      public void Delete(int id)
      {
      }
   }
}
