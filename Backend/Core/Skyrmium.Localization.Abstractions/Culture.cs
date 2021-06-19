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

      public bool Equals(ICulture? other)
      {
         return other is not null && this.CultureEnum == other.CultureEnum;
      }

      public override bool Equals(object? obj)
      {
         return Equals(obj as Culture);
      }

      public override int GetHashCode()
      {
         return this.CultureEnum.GetHashCode();
      }

      public override string ToString()
      {
         return this.IsoCode;
      }

      public static bool operator ==(Culture? left, Culture? right)
      {
         return left is not null && left.Equals(right);
      }

      public static bool operator !=(Culture? left, Culture? right)
      {
         return !(left == right);
      }
   }
}
