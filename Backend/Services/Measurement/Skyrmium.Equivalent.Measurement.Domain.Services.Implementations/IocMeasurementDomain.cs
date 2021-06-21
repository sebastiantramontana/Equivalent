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
         RegisterLocalizationForEntity<IConversionLocalizer, ConversionLocalizerFactory, EnUsConversionLocalizer, EsEsConversionLocalizer>(container);
         RegisterLocalizationForEntity<IMeasureEquivalenceLocalizer, MeasureEquivalenceLocalizerFactory, EnUsMeasureEquivalenceLocalizer, EsEsMeasureEquivalenceLocalizer>(container);
      }

      private void RegisterLocalizationForEntity<TLocalizer, TFactory, TEnUs, TEsEs>(IContainer container)
         where TLocalizer : class, ILocalizer
         where TFactory : class, ILocalizerFactory<TLocalizer>
         where TEnUs : class, TLocalizer
         where TEsEs : class, TLocalizer
      {
         container.Register<TEnUs>();
         container.Register<TEsEs>();
         container.Register<ILocalizerFactory<TLocalizer>, TFactory>();
         container.Register(locator => CreateLocalizer<TLocalizer>(locator));
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
