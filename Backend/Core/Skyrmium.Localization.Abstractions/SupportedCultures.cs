using Skyrmium.Localization.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Skyrmium.Localization.Abstractions
{
   public static class SupportedCultures
   {
      public static ICulture EnUS { get; } = new Culture(CulturesEnum.enUS, "en-US");
      public static ICulture EsES { get; } = new Culture(CulturesEnum.esES, "es-ES");

      public static IEnumerable<ICulture> All { get; } = new[]
      {
         EnUS,
         EsES
      };

      public static ICulture FromIsoCode(string isoCode)
      {
         return All.SingleOrDefault(sc => sc.IsoCode == isoCode)
            ?? throw new BadIsoCodeCultureException();
      }
   }
}
