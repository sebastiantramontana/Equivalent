using Skyrmium.Domain.Entities.Contracts.Exceptions.Business;
using Skyrmium.Domain.Entities.Core;
using System.Collections.Generic;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities.Exceptions.Business
{
   internal static class BusinessExceptionFactory
   {
      internal static BusinessException<MeasurementException,InexistentEquivalenceExceptionValue> CreateInexistentEquivalenceException(Measure from, Measure to)
      {
         var values = new Dictionary<InexistentEquivalenceExceptionValue, object>(2)
         {
            { InexistentEquivalenceExceptionValue.FromMeasure, from },
            { InexistentEquivalenceExceptionValue.ToMeasure, to }
         };

         var info = new BusinessExceptionInfo<MeasurementException, InexistentEquivalenceExceptionValue>(MeasurementException.InexistentEquivalence, values);
         return new BusinessException<MeasurementException, InexistentEquivalenceExceptionValue>("Equivalence", info);
      }
   }
}
