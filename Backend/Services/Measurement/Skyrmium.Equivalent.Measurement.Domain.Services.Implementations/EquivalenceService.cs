using Skyrmium.Domain.Contracts.Exceptions;
using Skyrmium.Domain.Contracts.Repositories;
using Skyrmium.Domain.Services.Implementations;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts.Exceptions;
using System;

namespace Skyrmium.Equivalent.Measurement.Domain.Services.Implementations
{
   internal class EquivalenceService : OwnedCrudServiceBase<MeasureEquivalence>, IEquivalenceService
   {
      public EquivalenceService(IOwnedRepository<MeasureEquivalence> repository)
         : base(repository)
      {
      }

      public double GetFactor(Measure measureFrom, Measure measureTo)
      {
         var businessException = EquivalenceNotFoundExceptionFactory.Create(measureFrom, measureTo);
         var from = new MeasureIngredient(measureFrom, Guid.Empty);
         var to = new MeasureIngredient(measureTo, Guid.Empty);

         return GetFactor(from, to, businessException);
      }

      public double GetFactor(Measure measureFrom, Measure measureTo, Guid ingredient)
      {
         var businessException = EquivalenceNotFoundExceptionFactory.Create(measureFrom, measureTo, ingredient);
         var from = new MeasureIngredient(measureFrom, ingredient);
         var to = new MeasureIngredient(measureTo, ingredient);

         return GetFactor(from, to, businessException);
      }

      public double GetFactor(MeasureIngredient from, MeasureIngredient to)
      {
         var businessException = EquivalenceNotFoundExceptionFactory.Create(from.Measure, to.Measure, from.Ingredient, to.Ingredient);
         return GetFactor(from, to, businessException);
      }

      private double GetFactor(MeasureIngredient from, MeasureIngredient to, IBusinessException<MeasurementServiceExceptions, EquivalenceNotFoundExceptionValues> businessException)
      {
         var measureEquivalence = this.Repository
            .Query()
            .SingleOrDefault(me =>
                  me.From == from
               && me.To == to);

         return measureEquivalence?.Factor ?? throw businessException.ToException();
      }
   }
}
