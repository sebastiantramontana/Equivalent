using System.Collections.Generic;
using Skyrmium.Localization.Contracts;

namespace Skyrmium.Localization.Abstractions
{
   public static class SupportedCultures
   {
      public static Culture EnUS { get; } = new Culture(CulturesEnum.enUS, "en-US");
      public static Culture EsES { get; } = new Culture(CulturesEnum.esES, "es-ES");

      public static IEnumerable<Culture> All { get; } = new[]
      {
         EnUS,
         EsES
      };
   }
}
