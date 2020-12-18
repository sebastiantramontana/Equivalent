using Skyrmium.Domain.Contracts;
using Skyrmium.Domain.Contracts.Exceptions;
using Skyrmium.Domain.Implementations.Exceptions;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts.Exceptions.Business;
using System.Collections.Generic;

namespace Skyrmium.Equivalent.Measurement.Domain.Services.Implementations
{
   internal static class InexistentEquivalenceExceptionFactory
   {
      internal static IBusinessException<MeasurementException, InexistentEquivalenceExceptionValue> Create(Measure from, Measure to)
      {
         var values = new Dictionary<InexistentEquivalenceExceptionValue, object>(2)
         {
            { InexistentEquivalenceExceptionValue.FromMeasure, from },
            { InexistentEquivalenceExceptionValue.ToMeasure, to }
         };

         return Create(values);
      }

      internal static IBusinessException<MeasurementException, InexistentEquivalenceExceptionValue> Create(Measure from, Measure to, IDistributableId ingredient)
      {
         var values = new Dictionary<InexistentEquivalenceExceptionValue, object>(3)
         {
            { InexistentEquivalenceExceptionValue.FromMeasure, from },
            { InexistentEquivalenceExceptionValue.ToMeasure, to },
            { InexistentEquivalenceExceptionValue.Ingredient, ingredient }
         };

         return Create(values);
      }

      internal static IBusinessException<MeasurementException, InexistentEquivalenceExceptionValue> Create(Measure from, Measure to, IDistributableId ingredientFrom, IDistributableId ingredientTo)
      {
         var values = new Dictionary<InexistentEquivalenceExceptionValue, object>(4)
         {
            { InexistentEquivalenceExceptionValue.FromMeasure, from },
            { InexistentEquivalenceExceptionValue.ToMeasure, to },
            { InexistentEquivalenceExceptionValue.FromIngredient, ingredientFrom },
            { InexistentEquivalenceExceptionValue.ToIngredient, ingredientTo }
         };

         return Create(values);
      }

      private static IBusinessException<MeasurementException, InexistentEquivalenceExceptionValue> Create(IDictionary<InexistentEquivalenceExceptionValue, object> values)
      {
         return BusinessExceptionFactory.Create(MeasurementException.InexistentEquivalence, "Equivalence", values);
      }
   }
}
