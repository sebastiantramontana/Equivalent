using Skyrmium.Domain.Contracts.Exceptions;
using Skyrmium.Domain.Contracts.Repositories;
using Skyrmium.Domain.Services.Implementations;
using Skyrmium.Equivalent.Measurement.Dal.Repositories;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts.Exceptions;
using System;
using System.Threading.Tasks;

namespace Skyrmium.Equivalent.Measurement.Domain.Services.Implementations
{
   internal class EquivalenceService : OwnedCrudServiceBase<IMeasureEquivalenceRepository, MeasureEquivalence>, IEquivalenceService
   {
      private readonly IRepository<Measure> _measureRepository;

      public EquivalenceService(IMeasureEquivalenceRepository repository, IRepository<Measure> measureRepository)
         : base(repository)
      {
         _measureRepository = measureRepository;
      }

      public async Task<double> GetFactor(Guid measureFrom, Guid measureTo)
      {
         var measureEquivalence = await this.Repository.GetByMeasures(measureFrom, measureFrom)
            ?? throw await GetException(measureFrom, measureTo);

         return GetEquivalenceFactor(measureEquivalence, measureFrom, measureTo);
      }

      public async Task<double> GetFactor(Guid measureFrom, Guid measureTo, Guid ingredient)
      {
         var measureEquivalence = await this.Repository.GetForIngredient(measureFrom, measureTo, ingredient)
            ?? throw await GetException(measureFrom, measureTo, ingredient);

         return GetEquivalenceFactor(measureEquivalence, measureFrom, measureTo);
      }

      public async Task<double> GetFactor(Guid measureFrom, Guid ingredientFrom, Guid measureTo, Guid ingredientTo)
      {
         var measureEquivalence = await this.Repository.GetByMeasureIngredients(measureFrom, ingredientFrom, measureTo, ingredientTo)
            ?? throw await GetException(measureFrom, ingredientFrom, measureTo, ingredientTo);

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

      private Task<Exception> GetException(Guid measureFrom, Guid measureTo)
      {
         return GetException(measureFrom, measureTo, (from, to) => EquivalenceNotFoundExceptionFactory.Create(from, to));
      }

      private Task<Exception> GetException(Guid measureFrom, Guid measureTo, Guid ingredient)
      {
         return GetException(measureFrom, measureTo, (from, to) => EquivalenceNotFoundExceptionFactory.Create(from, to, ingredient));
      }

      private Task<Exception> GetException(Guid measureFromId, Guid ingredientFrom, Guid measureToId, Guid ingredientTo)
      {
         return GetException(measureFromId, measureToId, (measureFrom, measureTo) => EquivalenceNotFoundExceptionFactory.Create(measureFrom, measureTo, ingredientFrom, ingredientTo));
      }

      private async Task<Exception> GetException(Guid measureFrom, Guid measureTo, Func<Measure, Measure, IBusinessException<MeasurementServiceExceptions, EquivalenceNotFoundExceptionValues>> bussinesExceptionFunc)
      {
         var from = GetMeasure(measureFrom);
         var to = GetMeasure(measureTo);

         var bussinessException = bussinesExceptionFunc(await from, await to);

         return bussinessException.ToException();
      }

      private Task<Measure> GetMeasure(Guid measureDistributedId)
      {
         return _measureRepository.GetByDistributedIdAsync(measureDistributedId);
      }
   }
}
