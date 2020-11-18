using Skyrmium.Domain.Entities.Contracts;
using Skyrmium.Domain.Services.Contracts;
using Skyrmium.Equivalent.Measurement.Domain.Entities;

namespace Skyrmium.Equivalent.Measurement.Domain.Services.Contracts
{
   public interface IEquivalenceService : ICrudService<MeasureEquivalence>
   {
      double Convert(Measure from, Measure to);
      double Convert(Measure from, Measure to, IDistributableId ingredient);
      double Convert(Measure measureFrom, Measure measureTo, IDistributableId ingredientFrom, IDistributableId ingredientTo);
   }
}
