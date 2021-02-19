using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts;
using System;
using System.Collections.Generic;

namespace Skyrmium.Equivalent.Measurement.Domain.Services.Implementations
{
   public class IocMeasurementDomainServices
   {
      public IEnumerable<(Type Interfaz, Type Implementation)> TypePairs =>
         new (Type Interfaz, Type Implementation)[]
         {
            (typeof(IConversionService),typeof(ConversionService)),
            (typeof(IEquivalenceService),typeof(EquivalenceService)),
            (typeof(IMeasureService),typeof(MeasureService))
         };
   }
}
