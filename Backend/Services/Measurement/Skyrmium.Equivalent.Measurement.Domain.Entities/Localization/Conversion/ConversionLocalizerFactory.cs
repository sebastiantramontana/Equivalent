using Skyrmium.Localization.Abstractions;
using Skyrmium.Localization.Contracts;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities.Localization.Conversion
{
   public class ConversionLocalizerFactory : LocalizerFactoryBase<IConversionLocalizer>
   {
      public ConversionLocalizerFactory(EnUsConversionLocalizer enUs, EsEsConversionLocalizer esEs)
         : base(new IConversionLocalizer[]
         {
            enUs,
            esEs
         })
      {
      }
   }
}
