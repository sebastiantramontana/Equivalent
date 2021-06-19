using Skyrmium.Localization.Contracts;

namespace Skyrmium.Localization.Abstractions
{
   internal sealed class Culture : ICulture
   {
      internal Culture(CulturesEnum cultureEnum, string isoCode)
      {
         CultureEnum = cultureEnum;
         IsoCode = isoCode;
      }

      public CulturesEnum CultureEnum { get; private set; }
      public string IsoCode { get; private set; }

      public void SetNewCulture(CulturesEnum culturesEnum, string isoCode)
      {
         this.CultureEnum = culturesEnum;
         this.IsoCode = isoCode;
      }

      public override string ToString()
      {
         return this.IsoCode;
      }
   }
}
