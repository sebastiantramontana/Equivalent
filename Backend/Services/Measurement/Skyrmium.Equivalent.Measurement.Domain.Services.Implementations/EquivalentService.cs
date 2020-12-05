using Skyrmium.Dal.Contracts.Repositories;
using Skyrmium.Domain.Contracts;
using Skyrmium.Domain.Contracts.Exceptions.Business;
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

      public double Convert(Measure measureFrom, Measure measureTo)
      {
         var businessException = BusinessExceptionFactory.CreateInexistentEquivalenceException(measureFrom, measureTo);
         return Convert(measureFrom, measureTo, DistributableId.None, DistributableId.None, businessException);
      }

      public double Convert(Measure measureFrom, Measure measureTo, IDistributableId ingredient)
      {
         var businessException = BusinessExceptionFactory.CreateInexistentEquivalenceException(measureFrom, measureTo, ingredient);
         return Convert(measureFrom, measureTo, ingredient, ingredient, businessException);
      }

      public double Convert(Measure measureFrom, Measure measureTo, IDistributableId ingredientFrom, IDistributableId ingredientTo)
      {
         var businessException = BusinessExceptionFactory.CreateInexistentEquivalenceException(measureFrom, measureTo, ingredientFrom, ingredientTo);
         return Convert(measureFrom, measureTo, ingredientFrom, ingredientTo, businessException);
      }

      private double Convert(Measure measureFrom, Measure measureTo, IDistributableId ingredientFrom, IDistributableId ingredientTo, BusinessException<MeasurementException, InexistentEquivalenceExceptionValue> businessException)
      {
         var measureEquivalence = this.Repository
            .Query()
            .SingleOrDefault(me =>
                  me.MeasureFrom == measureFrom
               && me.MeasureTo == measureTo
               && me.IngredientFrom == ingredientFrom
               && me.IngredientTo == ingredientTo);

         return measureEquivalence?.Factor ?? throw businessException;
      }
   }
}
