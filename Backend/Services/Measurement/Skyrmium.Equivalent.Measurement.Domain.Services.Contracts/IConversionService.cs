using Skyrmium.Domain.Services.Contracts;
using Skyrmium.Equivalent.Measurement.Domain.Entities;

namespace Skyrmium.Equivalent.Measurement.Domain.Services.Contracts
{
   public interface IConversionService : IOwnedCrudService<Conversion>
   {
      double Convert(Conversion conversion, double quantity);
   }
}
