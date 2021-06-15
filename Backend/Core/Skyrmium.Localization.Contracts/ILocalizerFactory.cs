namespace Skyrmium.Localization.Contracts
{
   public interface ILocalizerFactory
   {
      ILocalizer GetLocalizer(Language language);
   }
}
