using Skyrmium.Domain.Contracts.Repositories;
using Skyrmium.Domain.Services.Contracts;
using Skyrmium.Domain.Services.Implementations;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts;

namespace Skyrmium.Equivalent.Measurement.Domain.Services.Implementations
{
   public class MeasureService : OwnedCrudServiceBase<Measure>, IMeasureService
   {
      public MeasureService(IOwnedRepository<Measure> repository)
         : base(repository)
      {
      }
   }
}
