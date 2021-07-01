﻿using System;
using System.Threading.Tasks;
using Skyrmium.Domain.Contracts.Exceptions;
using Skyrmium.Domain.Services.Implementations;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Entities.Localization.MeasureEquivalence;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts.Repositories;

namespace Skyrmium.Equivalent.Measurement.Domain.Services.Implementations
{
   public class EquivalenceService : OwnedCrudServiceBase<IMeasureEquivalenceRepository, MeasureEquivalence>, IEquivalenceService
   {
      private readonly IMeasureEquivalenceLocalizer _localizer;

      public EquivalenceService(IMeasureEquivalenceRepository repository, IMeasureEquivalenceLocalizer localizer)
         : base(repository)
      {
         _localizer = localizer;
      }

      public Task<double> GetFactor(Guid measureFrom, Guid measureTo)
      {
         return GetFactor(measureFrom, measureTo, () => this.Repository.GetByMeasuresCrossed(measureFrom, measureTo));
      }

      public Task<double> GetFactor(Guid measureFrom, Guid measureTo, Guid ingredient)
      {
         return GetFactor(measureFrom, measureTo, () => this.Repository.GetByIngredientCrossed(measureFrom, measureTo, ingredient));
      }

      public Task<double> GetFactor(Guid measureFrom, Guid ingredientFrom, Guid measureTo, Guid ingredientTo)
      {
         return GetFactor(measureFrom, measureTo, () => this.Repository.GetByMeasureIngredientsCrossed(measureFrom, ingredientFrom, measureTo, ingredientTo));
      }

      private async Task<double> GetFactor(Guid measureFrom, Guid measureTo, Func<Task<MeasureEquivalence>> getMeasureEquivalenceFunc)
      {
         ValidateMeasures(measureFrom, measureTo);

         if (measureFrom == measureTo)
            return 1.0;

         var measureEquivalence = await getMeasureEquivalenceFunc();

         return GetEquivalenceFactor(measureEquivalence, measureFrom, measureTo);
      }

      private static double GetEquivalenceFactor(MeasureEquivalence measureEquivalence, Guid originalMeasureFrom, Guid originalMeasureTo)
      {
         var factor = measureEquivalence.Factor;

         if (CheckMeasuresAreCrossed(measureEquivalence, originalMeasureFrom, originalMeasureTo))
            factor = 1 / factor;

         return factor;
      }

      private void ValidateMeasures(Guid measureFrom, Guid measureTo)
      {
         if (measureFrom == Guid.Empty || measureTo == Guid.Empty)
            throw new BusinessException(_localizer.InvalidEquivalence, _localizer.EmptyMeasures);
      }

      private static bool CheckMeasuresAreCrossed(MeasureEquivalence measureEquivalence, Guid originalMeasureFrom, Guid originalMeasureTo)
      {
         return
            measureEquivalence.From.Measure.Id == originalMeasureTo &&
            measureEquivalence.To.Measure.Id == originalMeasureFrom;
      }
   }
}