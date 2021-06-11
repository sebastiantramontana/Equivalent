using Skyrmium.Domain.Contracts.Exceptions;
using Skyrmium.Domain.Services.Implementations;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts.Exceptions;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skyrmium.Equivalent.Measurement.Domain.Services.Implementations
{
   internal class ConversionService : OwnedCrudServiceBase<IConversionRepository, Conversion>, IConversionService
   {
      public ConversionService(IConversionRepository repository) : base(repository)
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

      public async Task<double> Convert(MeasureEquivalence from, MeasureEquivalence to, double quantity)
      {
         //TODO: REVIEW
         var conversion = await this.Repository.Search(from.Id, to.Id)
            ?? throw new BusinessException ("Conversión no encontrada","No se encontró una conversión para las equivalencias dadas"); //CreateConversionNotFoundException(from, to);

         return Convert(conversion, quantity);
      }

      //private static Exception CreateConversionNotFoundException(MeasureEquivalence from, MeasureEquivalence to)
      //{
      //   return BusinessExceptionFactory
      //      .Create(MeasurementServiceExceptions.ConversionNotFound, "Conversion",
      //         new Dictionary<ConversionNotFoundExceptionValues, object>()
      //         {
      //            { ConversionNotFoundExceptionValues.From, from },
      //            { ConversionNotFoundExceptionValues.To, to }
      //         })
      //      .ToException();
      //}
   }
}
