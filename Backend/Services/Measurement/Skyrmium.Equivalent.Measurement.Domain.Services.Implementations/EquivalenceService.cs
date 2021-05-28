using Skyrmium.Domain.Implementations.Exceptions;
using Skyrmium.Domain.Services.Implementations;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts.Exceptions;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skyrmium.Equivalent.Measurement.Domain.Services.Implementations
{
   internal class EquivalenceService : OwnedCrudServiceBase<IMeasureEquivalenceRepository, MeasureEquivalence>, IEquivalenceService
   {
      public EquivalenceService(IMeasureEquivalenceRepository repository)
         : base(repository)
      {
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

      private static async Task<double> GetFactor(Guid measureFrom, Guid measureTo, Func<Task<MeasureEquivalence>> getMeasureEquivalenceFunc)
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

      private static void ValidateMeasures(Guid measureFrom, Guid measureTo)
      {
         if (measureFrom == Guid.Empty || measureTo == Guid.Empty)
         {
            var info = new BusinessExceptionInfo<MeasurementServiceExceptions, InvalidNullMeasure>(
               MeasurementServiceExceptions.InvalidNullMeasure,
               new Dictionary<InvalidNullMeasure, object>
               {
                  { InvalidNullMeasure.From, measureFrom},
                  { InvalidNullMeasure.To, measureTo}
               });

            throw new BusinessException<MeasurementServiceExceptions, InvalidNullMeasure>("Invalid Null Measure", info);
         }
      }

      private static bool CheckMeasuresAreCrossed(MeasureEquivalence measureEquivalence, Guid originalMeasureFrom, Guid originalMeasureTo)
      {
         return
            measureEquivalence.From.Measure.Id == originalMeasureTo &&
            measureEquivalence.To.Measure.Id == originalMeasureFrom;
      }
   }
}
