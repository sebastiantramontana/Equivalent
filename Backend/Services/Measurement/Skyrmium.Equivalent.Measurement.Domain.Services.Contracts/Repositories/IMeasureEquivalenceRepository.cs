using Skyrmium.Domain.Contracts.Repositories;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Skyrmium.Equivalent.Measurement.Domain.Services.Contracts.Repositories
{
   public interface IMeasureEquivalenceRepository : IOwnedRepository<MeasureEquivalence>
   {
      Task<MeasureEquivalence> GetByMeasuresCrossed(Guid meaureFrom, Guid measureTo);
      Task<MeasureEquivalence> GetByIngredientCrossed(Guid meaureFrom, Guid measureTo, Guid ingredient);
      Task<MeasureEquivalence> GetByMeasureIngredientsCrossed(Guid meaureFrom, Guid ingredientFrom, Guid measureTo, Guid ingredientTo);
   }
}
