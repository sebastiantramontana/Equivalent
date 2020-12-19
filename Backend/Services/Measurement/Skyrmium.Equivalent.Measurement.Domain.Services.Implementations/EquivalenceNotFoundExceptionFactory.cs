using Skyrmium.Domain.Contracts;
using Skyrmium.Domain.Contracts.Exceptions;
using Skyrmium.Domain.Implementations.Exceptions;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts.Exceptions;
using System.Collections.Generic;

namespace Skyrmium.Equivalent.Measurement.Domain.Services.Implementations
{
   internal static class EquivalenceNotFoundExceptionFactory
   {
      internal static IBusinessException<MeasurementServiceExceptions, EquivalenceNotFoundExceptionValues> Create(Measure from, Measure to)
      {
         var values = new Dictionary<EquivalenceNotFoundExceptionValues, object>(2)
         {
            { EquivalenceNotFoundExceptionValues.FromMeasure, from },
            { EquivalenceNotFoundExceptionValues.ToMeasure, to }
         };

         return Create(values);
      }

      internal static IBusinessException<MeasurementServiceExceptions, EquivalenceNotFoundExceptionValues> Create(Measure from, Measure to, IDistributableId ingredient)
      {
         var values = new Dictionary<EquivalenceNotFoundExceptionValues, object>(3)
         {
            { EquivalenceNotFoundExceptionValues.FromMeasure, from },
            { EquivalenceNotFoundExceptionValues.ToMeasure, to },
            { EquivalenceNotFoundExceptionValues.Ingredient, ingredient }
         };

         return Create(values);
      }

      internal static IBusinessException<MeasurementServiceExceptions, EquivalenceNotFoundExceptionValues> Create(Measure from, Measure to, IDistributableId ingredientFrom, IDistributableId ingredientTo)
      {
         var values = new Dictionary<EquivalenceNotFoundExceptionValues, object>(4)
         {
            { EquivalenceNotFoundExceptionValues.FromMeasure, from },
            { EquivalenceNotFoundExceptionValues.ToMeasure, to },
            { EquivalenceNotFoundExceptionValues.FromIngredient, ingredientFrom },
            { EquivalenceNotFoundExceptionValues.ToIngredient, ingredientTo }
         };

         return Create(values);
      }

      private static IBusinessException<MeasurementServiceExceptions, EquivalenceNotFoundExceptionValues> Create(IDictionary<EquivalenceNotFoundExceptionValues, object> values)
      {
         return BusinessExceptionFactory.Create(MeasurementServiceExceptions.EquivalenceNotFound, "Equivalence", values);
      }
   }
}
