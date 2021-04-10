using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Services.Contracts;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using System;

namespace Skyrmium.Equivalent.Measurement.Domain.Services.Contracts
{
   public interface IEquivalenceService : IOwnedCrudService<MeasureEquivalence>
   {
      double GetFactor(Measure from, Measure to);
      double GetFactor(Measure from, Measure to, Guid ingredient);
      double GetFactor(MeasureIngredient from, MeasureIngredient to);
   }
}
