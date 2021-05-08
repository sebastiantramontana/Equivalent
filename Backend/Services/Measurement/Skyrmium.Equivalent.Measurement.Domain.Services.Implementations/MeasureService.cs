using Skyrmium.Domain.Services.Contracts.Repositories;
using Skyrmium.Domain.Services.Implementations;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts;

namespace Skyrmium.Equivalent.Measurement.Domain.Services.Implementations
{
   internal class MeasureService : OwnedCrudServiceBase<IOwnedRepository<Measure>, Measure>, IMeasureService
   {
      public MeasureService(IOwnedRepository<Measure> repository)
         : base(repository)
      {
      }
   }
}
