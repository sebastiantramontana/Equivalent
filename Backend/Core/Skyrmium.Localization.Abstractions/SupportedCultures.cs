using Skyrmium.Localization.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Skyrmium.Localization.Abstractions
{
   internal class SupportedCultures : ISupportedCultures
   {
      public ICulture EnUS { get; } = new Culture(CulturesEnum.enUS, "en-US");
      public ICulture EsES { get; } = new Culture(CulturesEnum.esES, "es-ES");

      public IEnumerable<ICulture> All => new[]
      {
         this.EnUS,
         this.EsES
      };

      public ICulture FromIsoCode(string isoCode)
      {
         return this.All.SingleOrDefault(sc => sc.IsoCode == isoCode)
            ?? throw new BadIsoCodeCultureException();
      }
   }
}
