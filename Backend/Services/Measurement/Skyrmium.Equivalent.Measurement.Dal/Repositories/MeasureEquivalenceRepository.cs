using Microsoft.EntityFrameworkCore;
using Skyrmium.Dal.Implementations.Repositories;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts.Repositories;
using Skyrmium.Infrastructure.Contracts;
using System;
using System.Threading.Tasks;

namespace Skyrmium.Equivalent.Measurement.Dal.Repositories
{
   internal class MeasureEquivalenceRepository : OwnedRepository<MeasureEquivalence, MeasureEquivalenceDao>, IMeasureEquivalenceRepository
   {
      public MeasureEquivalenceRepository(DbContext dbContext, IMapper<MeasureEquivalence, MeasureEquivalenceDao> mapper)
         : base(dbContext, mapper)
      {
      }

      public Task<MeasureEquivalence> GetByMeasures(Guid meaureFrom, Guid measureTo)
      {
         return GetByMeasureIngredients(meaureFrom, Guid.Empty, measureTo, Guid.Empty);
      }

      public Task<MeasureEquivalence> GetForIngredient(Guid meaureFrom, Guid measureTo, Guid ingredient)
      {
         return GetByMeasureIngredients(meaureFrom, ingredient, measureTo, ingredient);
      }

      public Task<MeasureEquivalence> GetByMeasureIngredients(Guid measureFrom, Guid ingredientFrom, Guid measureTo, Guid ingredientTo)
      {
         return GetSingleEntityAsync(d =>
                  (d.MeasureFrom.DistributedId == measureFrom
                  && d.IngredientFrom == ingredientFrom
                  && d.MeasureTo.DistributedId == measureTo
                  && d.IngredientTo == ingredientTo)
                  ||
                  (d.MeasureTo.DistributedId == measureFrom
                  && d.IngredientTo == ingredientFrom
                  && d.MeasureFrom.DistributedId == measureTo
                  && d.IngredientFrom == ingredientTo));
      }
   }
}
