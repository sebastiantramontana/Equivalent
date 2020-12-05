using Skyrmium.Dal.Contracts.Repositories;
using Skyrmium.Domain.Services.Contracts;
using Skyrmium.Domain.Services.Implementations;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts;

namespace Skyrmium.Equivalent.Measurement.Domain.Services.Implementations
{
   public class MeasureService : OwnedDistributableCrudServiceBase<Measure>, IMeasureService
   {
      public MeasureService(IOwnedDistributableRepository<Measure> repository, IDistributableCrudService<Measure> distributableCrudService, IOwnedCrudService<Measure> ownedCrudService)
         : base(repository, distributableCrudService, ownedCrudService)
      {
      }
   }
}
