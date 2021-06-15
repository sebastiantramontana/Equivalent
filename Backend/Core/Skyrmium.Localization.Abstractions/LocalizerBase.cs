using Skyrmium.Localization.Contracts;

namespace Skyrmium.Localization.Abstractions
{
   public abstract class LocalizerBase : ILocalizer
   {
      protected LocalizerBase(Language Language)
      {
         this.Language = Language;
      }

      public Language Language { get; }
   }
}
