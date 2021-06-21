using System.Collections.Generic;

namespace Skyrmium.Localization.Contracts
{
   public interface ISupportedCultures
   {
      IEnumerable<ICulture> All { get; }
      ICulture EnUS { get; }
      ICulture EsES { get; }
      ICulture FromIsoCode(string isoCode);
   }
}