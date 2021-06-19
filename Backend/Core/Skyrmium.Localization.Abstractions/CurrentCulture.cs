using Skyrmium.Localization.Contracts;

namespace Skyrmium.Localization.Abstractions
{
   internal class CurrentCulture : ICurrentCulture
   {
      public ICulture Culture { get; set; } = new Culture(CulturesEnum.enUS, "en-US");
   }
}
