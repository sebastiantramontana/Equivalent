using System.Collections.Generic;
using Skyrmium.Localization.Contracts;

namespace Skyrmium.Localization.Abstractions
{
   public static class SupportedLanguages
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
