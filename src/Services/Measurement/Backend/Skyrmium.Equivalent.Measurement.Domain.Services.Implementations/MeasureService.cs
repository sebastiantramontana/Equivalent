using Skyrmium.Domain.Services.Contracts.Repositories;
using Skyrmium.Domain.Services.Implementations;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts.Repositories;

namespace Skyrmium.Equivalent.Measurement.Domain.Services.Implementations
{
   public class MeasureService : OwnedCrudServiceBase<IOwnedRepository<Measure>, Measure>, IMeasureService
   {
      public MeasureService(IMeasureRepository repository)
         : base(repository)
      {
      }
   }
}
