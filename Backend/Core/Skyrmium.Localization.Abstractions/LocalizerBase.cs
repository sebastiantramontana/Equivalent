using Skyrmium.Localization.Contracts;

namespace Skyrmium.Localization.Abstractions
{
   public abstract class LocalizerBase : ILocalizer
   {
      protected LocalizerBase(ICulture culture)
      {
         this.Culture = culture;
      }

      public ICulture Culture { get; }
   }
}
