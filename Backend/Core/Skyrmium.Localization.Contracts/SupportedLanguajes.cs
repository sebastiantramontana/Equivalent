using System.Collections.Generic;

namespace Skyrmium.Localization.Contracts
{
   public static class SupportedLanguajes
   {
      public static Language EnUS { get; } = new Language(LanguagesEnum.enUS, "en-US");
      public static Language EsES { get; } = new Language(LanguagesEnum.esES, "es-ES");

      public static IEnumerable<Language> All { get; } = new[]
      {
         EnUS,
         EsES
      };
   }
}
