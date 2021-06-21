using Skyrmium.Localization.Abstractions;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities.Localization.Measure
{
   public class MeasureLocalizerFactory : LocalizerFactoryBase<IMeasureLocalizer>
   {
      public MeasureLocalizerFactory(EnUsMeasureLocalizer enUs, EsEsMeasureLocalizer esEs)
         : base(new IMeasureLocalizer[]
         {
            enUs,
            esEs
         })
      {
      }
   }
}
