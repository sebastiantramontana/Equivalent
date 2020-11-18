using Skyrmium.Dal.Contracts;
using Skyrmium.Domain.Services.Implementations;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts;

namespace Skyrmium.Equivalent.Measurement.Domain.Services.Implementations
{
   public class MeasureService : CrudServiceBase<Measure>, IMeasureService
   {
      public MeasureService(IRepository<Measure> repository) : base(repository)
      {
      }
   }
}
