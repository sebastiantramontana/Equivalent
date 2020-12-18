using Skyrmium.Domain.Contracts;
using Skyrmium.Domain.Contracts.Exceptions;
using Skyrmium.Domain.Contracts.Repositories;
using Skyrmium.Domain.Implementations;
using Skyrmium.Domain.Services.Implementations;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts.Exceptions.Business;

namespace Skyrmium.Equivalent.Measurement.Domain.Services.Implementations
{
   public class EquivalentService : OwnedCrudServiceBase<MeasureEquivalence>, IEquivalenceService
   {
      public EquivalentService(IOwnedRepository<MeasureEquivalence> repository)
         : base(repository)
      {
      }

      public double GetFactor(Measure measureFrom, Measure measureTo)
      {
         var businessException = InexistentEquivalenceExceptionFactory.Create(measureFrom, measureTo);
         var from = new MeasureIngredient(measureFrom, DistributableId.None);
         var to = new MeasureIngredient(measureTo, DistributableId.None);

         return GetFactor(from, to, businessException);
      }

      public double GetFactor(Measure measureFrom, Measure measureTo, IDistributableId ingredient)
      {
         var businessException = InexistentEquivalenceExceptionFactory.Create(measureFrom, measureTo, ingredient);
         var from = new MeasureIngredient(measureFrom, ingredient);
         var to = new MeasureIngredient(measureTo, ingredient);

         return GetFactor(from, to, businessException);
      }

      public double GetFactor(MeasureIngredient from, MeasureIngredient to)
      {
         var businessException = InexistentEquivalenceExceptionFactory.Create(from.Measure, to.Measure, from.Ingredient, to.Ingredient);
         return GetFactor(from, to, businessException);
      }

      private double GetFactor(MeasureIngredient from, MeasureIngredient to, IBusinessException<MeasurementException, InexistentEquivalenceExceptionValue> businessException)
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
