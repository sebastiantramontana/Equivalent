using Skyrmium.Domain.Contracts.Repositories;
using Skyrmium.Domain.Implementations.Exceptions;
using Skyrmium.Domain.Services.Implementations;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skyrmium.Equivalent.Measurement.Domain.Services.Implementations
{
   internal class ConversionService : OwnedCrudServiceBase<Conversion>, IConversionService
   {
      public ConversionService(IOwnedRepository<Conversion> repository) : base(repository)
      {
      }

      public double Convert(Conversion conversion)
      {
         double factor = 1.0;

         foreach (var equiv in conversion.Equivalences)
            factor *= equiv.MeasureEquivalence.Factor;

         return factor;
      }

      public double Convert(Conversion conversion, double quantity)
      {
         return quantity * Convert(conversion);
      }

      public double Convert(MeasureEquivalence from, MeasureEquivalence to, double quantity)
      {
         var conversion = this.Repository
                        .Query()
                        .SingleOrDefault(c => c.Equivalences.First().MeasureEquivalence == from && c.Equivalences.Last().MeasureEquivalence == to)
                        ?? throw CreateConversionNotFoundException(from, to);

         return Convert(conversion, quantity);
      }

      private static Exception CreateConversionNotFoundException(MeasureEquivalence from, MeasureEquivalence to)
      {
         return BusinessExceptionFactory
            .Create(MeasurementServiceExceptions.ConversionNotFound, "Conversion",
               new Dictionary<ConversionNotFoundExceptionValues, object>()
               {
                  { ConversionNotFoundExceptionValues.From, from },
                  { ConversionNotFoundExceptionValues.To, to }
               })
            .ToException();
      }
   }
}
