using Skyrmium.Domain.Contracts;
using Skyrmium.Domain.Services.Contracts;
using Skyrmium.Equivalent.Measurement.Domain.Entities;

namespace Skyrmium.Equivalent.Measurement.Domain.Services.Contracts
{
   public interface IEquivalenceService : IOwnedCrudService<MeasureEquivalence>
   {
      double GetFactor(Measure from, Measure to);
      double GetFactor(Measure from, Measure to, IDistributableId ingredient);
      double GetFactor(MeasureIngredient from, MeasureIngredient to);
   }
}
