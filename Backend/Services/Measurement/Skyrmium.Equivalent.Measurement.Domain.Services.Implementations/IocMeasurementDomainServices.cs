using System;
using System.Collections.Generic;
using Skyrmium.Equivalent.Measurement.Domain.Entities.Localization.Conversion;
using Skyrmium.Equivalent.Measurement.Domain.Entities.Localization.MeasureEquivalence;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts;
using Skyrmium.Localization.Contracts;

namespace Skyrmium.Equivalent.Measurement.Domain.Services.Implementations
{
   public class IocMeasurementDomainServices
   {
      public static IEnumerable<(Type Interfaz, Type Implementation)> TypePairs =>
         new (Type Interfaz, Type Implementation)[]
         {
            (typeof(IConversionService),typeof(ConversionService)),
            (typeof(IEquivalenceService),typeof(EquivalenceService)),
            (typeof(IMeasureService),typeof(MeasureService))
         };

      public static IEnumerable<(Type Type, Func<IServiceProvider, ILocalizer> Builder)> CreateLocalizerBuilders()
      {
         yield return (typeof(IMeasureEquivalenceLocalizer), sp => CreateLocalizer<IMeasureEquivalenceLocalizer>(GetCulture(sp), new EnUsMeasureEquivalenceLocalizer(), new EsEsMeasureEquivalenceLocalizer()));
         yield return (typeof(IConversionLocalizer), sp => CreateLocalizer<IConversionLocalizer>(GetCulture(sp), new EnUsConversionLocalizer(), new EsEsConversionLocalizer()));
      }

      private static CulturesEnum GetCulture(IServiceProvider serviceProvider)
      {
         return (CulturesEnum)serviceProvider.GetService(typeof(CulturesEnum))!;
      }

      private static TLocalizer CreateLocalizer<TLocalizer>(CulturesEnum language, TLocalizer enUs, TLocalizer esES)
         where TLocalizer : ILocalizer
      {
         TLocalizer localizer = language switch
         {
            CulturesEnum.enUS => enUs,
            CulturesEnum.esES => esES,
            _ => throw new NotImplementedException($"Language {language} not implemented"),
         };

         return localizer;
      }
   }
}
