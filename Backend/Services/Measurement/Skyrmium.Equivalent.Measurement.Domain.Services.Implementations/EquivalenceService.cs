using Skyrmium.Domain.Services.Implementations;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts.Repositories;
using System;
using System.Threading.Tasks;

namespace Skyrmium.Equivalent.Measurement.Domain.Services.Implementations
{
   internal class EquivalenceService : OwnedCrudServiceBase<IMeasureEquivalenceRepository, MeasureEquivalence>, IEquivalenceService
   {
      public EquivalenceService(IMeasureEquivalenceRepository repository)
         : base(repository)
      {
      }

      public async Task<double> GetFactor(Guid measureFrom, Guid measureTo)
      {
         var measureEquivalence = await this.Repository.GetByMeasures(measureFrom, measureFrom);

         return GetEquivalenceFactor(measureEquivalence, measureFrom, measureTo);
      }

      public async Task<double> GetFactor(Guid measureFrom, Guid measureTo, Guid ingredient)
      {
         var measureEquivalence = await this.Repository.GetForIngredient(measureFrom, measureTo, ingredient);

         return GetEquivalenceFactor(measureEquivalence, measureFrom, measureTo);
      }

      public async Task<double> GetFactor(Guid measureFrom, Guid ingredientFrom, Guid measureTo, Guid ingredientTo)
      {
         var measureEquivalence = await this.Repository.GetByMeasureIngredients(measureFrom, ingredientFrom, measureTo, ingredientTo);

         return GetEquivalenceFactor(measureEquivalence, measureFrom, measureTo);
      }

      private static double GetEquivalenceFactor(MeasureEquivalence measureEquivalence, Guid originalMeasureFrom, Guid originalMeasureTo)
      {
         var factor = measureEquivalence.Factor;

         if (CheckMeasuresAreCrossed(measureEquivalence, originalMeasureFrom, originalMeasureTo))
            factor = 1 / factor;

         return factor;
      }

      private static bool CheckMeasuresAreCrossed(MeasureEquivalence measureEquivalence, Guid originalMeasureFrom, Guid originalMeasureTo)
      {
         return
            measureEquivalence.From.Measure.DistributedId == originalMeasureTo &&
            measureEquivalence.To.Measure.DistributedId == originalMeasureFrom;
      }
   }
}
