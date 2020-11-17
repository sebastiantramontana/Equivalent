using Skyrmium.Domain.Entities.Contracts;
using Skyrmium.Equivalent.Measurement.Domain.Entities;

namespace Skyrmium.Equivalent.Measurement.Domain.Services.Contracts
{
   public interface IEquivalenceService
   {
      double Convert(Measure from, Measure to);
      double Convert(Measure from, Measure to, IDistributableId ingredient);
      double Convert(Measure measureFrom, Measure measureTo, IDistributableId ingredientFrom, IDistributableId ingredientTo);
   }
}
