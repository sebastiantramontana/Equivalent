﻿using Skyrmium.Dal.Contracts;
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
      public MeasureEquivalenceRepository(IDataAccess dataAccess, IMapper<MeasureEquivalence, MeasureEquivalenceDao> mapper)
         : base(dataAccess, mapper)
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
                  && d.IngredientFrom == ingredientTo),
                  "Equivalencia no encontrada");
      }

      protected override Task<MeasureEquivalenceDao> ContinueCreate(MeasureEquivalenceDao dao)
      {
         return this.DataAccess.Create(dao);
      }

      protected override Task<IEnumerable<MeasureEquivalenceDao>> ContinueCreate(IEnumerable<MeasureEquivalenceDao> daos)
      {
         return this.DataAccess.Create(daos);
      }

      protected override Task ContinueUpdate(MeasureEquivalenceDao dao)
      {
         return this.DataAccess.Update(dao);
      }

      protected override Task ContinueUpdate(IEnumerable<MeasureEquivalenceDao> daos)
      {
         return this.DataAccess.Update(daos);
      }

      protected override Task ContinueDelete(Guid id)
      {
         return this.DataAccess.Delete(new MeasureEquivalenceDao { Id = id });
      }

      protected override Task ContinueDelete(IEnumerable<Guid> ids)
      {
         return this.DataAccess.Delete(ids.Select(id => new MeasureEquivalenceDao { Id = id }));
      }
   }
}
