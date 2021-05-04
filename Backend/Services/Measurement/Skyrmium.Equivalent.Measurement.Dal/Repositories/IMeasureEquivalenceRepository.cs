using Skyrmium.Domain.Contracts.Repositories;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Skyrmium.Equivalent.Measurement.Dal.Repositories
{
   public interface IMeasureEquivalenceRepository : IOwnedRepository<MeasureEquivalence>
   {
      Task<MeasureEquivalence> GetByMeasures(Guid meaureFrom, Guid measureTo);
      Task<MeasureEquivalence> GetForIngredient(Guid meaureFrom, Guid measureTo, Guid ingredient);
      Task<MeasureEquivalence> GetByMeasureIngredients(Guid meaureFrom, Guid ingredientFrom, Guid measureTo, Guid ingredientTo);
   }
}
