using Skyrmium.Equivalent.Measurement.Domain.Entities.Localization.Conversion;
using Skyrmium.Equivalent.Measurement.Domain.Entities.Localization.MeasureEquivalence;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts;
using Skyrmium.Infrastructure.Contracts;
using Skyrmium.Localization.Contracts;

namespace Skyrmium.Equivalent.Measurement.Domain.Services.Implementations
{
   public class IocMeasurementDomain : IIocBulkRegistrar
   {
      public void Register(IContainer container)
      {
         RegisterLocalization(container);
         RegisterServices(container);
      }

      private void RegisterLocalization(IContainer container)
      {
         container.Register<ILocalizerFactory<IConversionLocalizer>, ConversionLocalizerFactory>();
         container.Register(locator => CreateLocalizer<IConversionLocalizer>(locator));

         container.Register<ILocalizerFactory<IMeasureEquivalenceLocalizer>, MeasureEquivalenceLocalizerFactory>();
         container.Register(locator => CreateLocalizer<IMeasureEquivalenceLocalizer>(locator));
      }

      private void RegisterServices(IContainer container)
      {
         container.Register<IConversionService, ConversionService>();
         container.Register<IEquivalenceService, EquivalenceService>();
         container.Register<IMeasureService, MeasureService>();
      }

      private static TLocalizer CreateLocalizer<TLocalizer>(IServiceLocator serviceLocator)
         where TLocalizer : ILocalizer
      {
         var currentCulture = serviceLocator.Resolve<ICurrentCulture>();
         var localizerFactory = serviceLocator.Resolve<ILocalizerFactory<TLocalizer>>();

         return localizerFactory.Create(currentCulture.Culture);
      }
   }
}
