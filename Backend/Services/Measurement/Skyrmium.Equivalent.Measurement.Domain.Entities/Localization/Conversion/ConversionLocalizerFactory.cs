using Skyrmium.Localization.Abstractions;
using Skyrmium.Localization.Contracts;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities.Localization.Conversion
{
   public class ConversionLocalizerFactory : LocalizerFactoryBase<IConversionLocalizer>
   {
      public ConversionLocalizerFactory(ISupportedCultures supportedCultures)
         : base(new IConversionLocalizer[]
         {
            new EnUsConversionLocalizer(supportedCultures),
            new EsEsConversionLocalizer(supportedCultures)
         })
      {
      }
   }
}
