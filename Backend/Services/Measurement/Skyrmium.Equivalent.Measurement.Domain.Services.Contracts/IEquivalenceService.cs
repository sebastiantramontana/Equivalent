using Skyrmium.Domain.Services.Contracts;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Skyrmium.Equivalent.Measurement.Domain.Services.Contracts
{
   public interface IEquivalenceService : IOwnedCrudService<MeasureEquivalence>
   {
      Task<double> GetFactor(Guid measureFrom, Guid measureTo);
      Task<double> GetFactor(Guid measureFrom, Guid measureTo, Guid ingredient);
      Task<double> GetFactor(Guid measureFrom, Guid ingredientFrom, Guid measureTo, Guid ingredientTo);
   }
}
