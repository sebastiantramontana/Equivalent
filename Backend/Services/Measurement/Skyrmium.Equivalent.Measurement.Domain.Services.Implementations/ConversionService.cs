using Skyrmium.Domain.Contracts.Repositories;
using Skyrmium.Domain.Services.Implementations;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts;

namespace Skyrmium.Equivalent.Measurement.Domain.Services.Implementations
{
   public class ConversionService : OwnedCrudServiceBase<Conversion>, IConversionService
   {
      public ConversionService(IOwnedRepository<Conversion> repository) : base(repository)
      {
      }

      public double Convert(Conversion conversion, double quantity)
      {
         return quantity * Convert(conversion);
      }

      public double Convert(Conversion conversion)
      {
         double factor = 1.0;

         foreach (var equiv in conversion.Equivalences)
            factor *= equiv.Factor;

         return factor;
      }
   }
}
