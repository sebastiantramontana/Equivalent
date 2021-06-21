using Skyrmium.Localization.Abstractions;
using Skyrmium.Localization.Contracts;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities.Localization.MeasureEquivalence
{
   public class MeasureEquivalenceLocalizerFactory : LocalizerFactoryBase<IMeasureEquivalenceLocalizer>
   {
      public MeasureEquivalenceLocalizerFactory(EnUsMeasureEquivalenceLocalizer enUs, EsEsMeasureEquivalenceLocalizer esEs)
         : base(new IMeasureEquivalenceLocalizer[]
         {
            enUs,
            esEs
         })
      {
      }
   }
}
