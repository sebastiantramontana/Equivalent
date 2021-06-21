using System.Threading.Tasks;
using Skyrmium.Domain.Contracts.Exceptions;
using Skyrmium.Domain.Services.Implementations;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Entities.Localization.Conversion;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts.Repositories;

namespace Skyrmium.Equivalent.Measurement.Domain.Services.Implementations
{
   internal class ConversionService : OwnedCrudServiceBase<IConversionRepository, Conversion>, IConversionService
   {
      private readonly IConversionLocalizer _localizer;

      public ConversionService(IConversionRepository repository, IConversionLocalizer localizer) : base(repository)
      {
         _localizer = localizer;
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
            ?? throw new BusinessException(_localizer.SerachedConversionNotFound, _localizer.SerachedConversionNotFoundForGivenEquivalences); //CreateConversionNotFoundException(from, to);

         return Convert(conversion, quantity);
      }
   }
}
