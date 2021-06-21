using Skyrmium.Domain.Services.Contracts.Repositories;
using Skyrmium.Equivalent.Measurement.Domain.Entities;

namespace Skyrmium.Equivalent.Measurement.Domain.Services.Contracts.Repositories
{
   public interface IMeasureRepository : IOwnedRepository<Measure>
   {
   }
}
