using Microsoft.EntityFrameworkCore;
using Skyrmium.Dal.Implementations.Repositories;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts.Repositories;
using Skyrmium.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skyrmium.Equivalent.Measurement.Dal.Repositories
{
   internal class MeasureEquivalenceRepository : OwnedRepositoryBase<MeasureEquivalence, MeasureEquivalenceDao>, IMeasureEquivalenceRepository
   {
      public MeasureEquivalenceRepository(DbContext dbContext, IMapper<MeasureEquivalence, MeasureEquivalenceDao> mapper)
         : base(dbContext, mapper)
      {
      }

      public Task<MeasureEquivalence> GetByMeasuresCrossed(Guid meaureFrom, Guid measureTo)
      {
         return GetByMeasureIngredientsCrossed(meaureFrom, Guid.Empty, measureTo, Guid.Empty);
      }

      public Task<MeasureEquivalence> GetByIngredientCrossed(Guid meaureFrom, Guid measureTo, Guid ingredient)
      {
         return GetByMeasureIngredientsCrossed(meaureFrom, ingredient, measureTo, ingredient);
      }

      public Task<MeasureEquivalence> GetByMeasureIngredientsCrossed(Guid measureFromId, Guid ingredientFrom, Guid measureToId, Guid ingredientTo)
      {
         return GetEntity(d =>
                  (d.MeasureFrom.Id == measureFromId
                  && d.IngredientFrom == ingredientFrom
                  && d.MeasureTo.Id == measureToId
                  && d.IngredientTo == ingredientTo)
                  ||
                  (d.MeasureTo.Id == measureFromId
                  && d.IngredientTo == ingredientFrom
                  && d.MeasureFrom.Id == measureToId
                  && d.IngredientFrom == ingredientTo));
      }

      protected override Task<MeasureEquivalenceDao> ContinueCreate(MeasureEquivalenceDao dao)
      {
         this.DbContext.Add(dao);
         return Task.FromResult(dao);
      }

      protected override Task<IEnumerable<MeasureEquivalenceDao>> ContinueCreate(IEnumerable<MeasureEquivalenceDao> daos)
      {
         this.DbContext.Set<MeasureEquivalenceDao>().AddRange(daos);
         return Task.FromResult(daos);
      }

      protected override Task ContinueUpdate(MeasureEquivalenceDao dao)
      {
         this.DbContext.Update(dao);
         return Task.CompletedTask;
      }

      protected override Task ContinueUpdate(IEnumerable<MeasureEquivalenceDao> daos)
      {
         this.DbContext.UpdateRange(daos);
         return Task.CompletedTask;
      }

      protected override Task ContinueDelete(Guid id)
      {
         this.DbContext.Remove(new MeasureEquivalenceDao { Id = id });
         return Task.CompletedTask;
      }

      protected override Task ContinueDelete(IEnumerable<Guid> ids)
      {
         this.DbContext
            .Set<MeasureEquivalenceDao>()
            .RemoveRange(ids.Select(id => new MeasureEquivalenceDao { Id = id }));

         return Task.CompletedTask;
      }
   }
}
