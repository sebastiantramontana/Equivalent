using System.Linq;
using Skyrmium.Localization.Contracts;

namespace Skyrmium.Localization.Abstractions
{
   public sealed class Culture
   {
      internal Culture(CulturesEnum languagesEnum, string isoCode)
      {
         LanguagesEnum = languagesEnum;
         IsoCode = isoCode;
      }

      public CulturesEnum LanguagesEnum { get; }
      public string IsoCode { get; }

      public static Culture FromIsoCode(string isoCode)
      {
         return SupportedCultures.All.SingleOrDefault(sc => sc.IsoCode == isoCode)
            ?? throw new BadIsoCodeCultureException();
      }
   }
}
