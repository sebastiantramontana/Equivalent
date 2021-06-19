namespace Skyrmium.Localization.Contracts
{
   public interface ILocalizerFactory<TLocalizer> where TLocalizer : ILocalizer
   {
      TLocalizer Create(ICulture culture);
   }
}
