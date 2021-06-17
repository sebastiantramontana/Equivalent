using Skyrmium.Localization.Contracts;

namespace Skyrmium.Localization.Abstractions
{
   public abstract class LocalizerBase : ILocalizer
   {
      protected LocalizerBase(Languages language)
      {
         this.Language = language;
      }

      public Languages Language { get; }
   }
}
