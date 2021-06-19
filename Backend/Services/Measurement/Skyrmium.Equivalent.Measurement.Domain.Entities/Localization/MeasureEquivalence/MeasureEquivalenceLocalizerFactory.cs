using Skyrmium.Localization.Abstractions;
using Skyrmium.Localization.Contracts;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities.Localization.MeasureEquivalence
{
   public class MeasureEquivalenceLocalizerFactory : LocalizerFactoryBase<IMeasureEquivalenceLocalizer>
   {
      public MeasureEquivalenceLocalizerFactory(ISupportedCultures supportedCultures)
         : base(new IMeasureEquivalenceLocalizer[]
         {
            new EnUsMeasureEquivalenceLocalizer(supportedCultures),
            new EsEsMeasureEquivalenceLocalizer(supportedCultures)
         })
      {
      }
   }
}
