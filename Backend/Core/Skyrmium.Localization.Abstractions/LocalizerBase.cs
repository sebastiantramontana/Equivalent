using Skyrmium.Localization.Contracts;

namespace Skyrmium.Localization.Abstractions
{
   public abstract class LocalizerBase : ILocalizer
   {
      protected LocalizerBase(CulturesEnum language)
      {
         this.Language = language;
      }

      public CulturesEnum Language { get; }
   }
}
