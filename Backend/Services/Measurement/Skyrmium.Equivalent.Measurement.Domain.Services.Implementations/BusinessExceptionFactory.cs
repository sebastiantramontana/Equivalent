using Skyrmium.Domain.Entities.Contracts;
using Skyrmium.Domain.Entities.Contracts.Exceptions.Business;
using Skyrmium.Domain.Entities.Core;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts.Exceptions.Business;
using System.Collections.Generic;

namespace Skyrmium.Equivalent.Measurement.Domain.Services.Implementations
{
   internal static class BusinessExceptionFactory
   {
      //TODO: DRY
      internal static BusinessException<MeasurementException, InexistentEquivalenceExceptionValue> CreateInexistentEquivalenceException(Measure from, Measure to)
      {
         var values = new Dictionary<InexistentEquivalenceExceptionValue, object>(2)
         {
            { InexistentEquivalenceExceptionValue.FromMeasure, from },
            { InexistentEquivalenceExceptionValue.ToMeasure, to }
         };

         var info = new BusinessExceptionInfo<MeasurementException, InexistentEquivalenceExceptionValue>(MeasurementException.InexistentEquivalence, values);
         return new BusinessException<MeasurementException, InexistentEquivalenceExceptionValue>("Equivalence", info);
      }

      internal static BusinessException<MeasurementException, InexistentEquivalenceExceptionValue> CreateInexistentEquivalenceException(Measure from, Measure to, IDistributableId ingredient)
      {
         var values = new Dictionary<InexistentEquivalenceExceptionValue, object>(2)
         {
            { InexistentEquivalenceExceptionValue.FromMeasure, from },
            { InexistentEquivalenceExceptionValue.ToMeasure, to },
            { InexistentEquivalenceExceptionValue.Ingredient, ingredient }
         };

         var info = new BusinessExceptionInfo<MeasurementException, InexistentEquivalenceExceptionValue>(MeasurementException.InexistentEquivalence, values);
         return new BusinessException<MeasurementException, InexistentEquivalenceExceptionValue>("Equivalence", info);
      }

      internal static BusinessException<MeasurementException, InexistentEquivalenceExceptionValue> CreateInexistentEquivalenceException(Measure from, Measure to, IDistributableId ingredientFrom, IDistributableId ingredientTo)
      {
         var values = new Dictionary<InexistentEquivalenceExceptionValue, object>(2)
         {
            { InexistentEquivalenceExceptionValue.FromMeasure, from },
            { InexistentEquivalenceExceptionValue.ToMeasure, to },
            { InexistentEquivalenceExceptionValue.FromIngredient, ingredientFrom },
            { InexistentEquivalenceExceptionValue.ToIngredient, ingredientTo }
         };

         var info = new BusinessExceptionInfo<MeasurementException, InexistentEquivalenceExceptionValue>(MeasurementException.InexistentEquivalence, values);
         return new BusinessException<MeasurementException, InexistentEquivalenceExceptionValue>("Equivalence", info);
      }
   }
}
