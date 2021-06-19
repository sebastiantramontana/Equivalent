using System;

namespace Skyrmium.Localization.Contracts
{
   public interface ICulture : IEquatable<ICulture>
   {
      CulturesEnum CultureEnum { get; }
      string IsoCode { get; }
   }
}