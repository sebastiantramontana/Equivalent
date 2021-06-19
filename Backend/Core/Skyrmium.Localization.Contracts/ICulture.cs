namespace Skyrmium.Localization.Contracts
{
   public interface ICulture
   {
      CulturesEnum CultureEnum { get; }
      string IsoCode { get; }

      void SetNewCulture(CulturesEnum culturesEnum, string isoCode);
   }
}