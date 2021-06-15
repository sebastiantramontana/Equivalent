using System;

namespace Skyrmium.Localization.Contracts
{
   public sealed class Language : IEquatable<Language>
   {
      private readonly LanguagesEnum _languagesEnum;

      internal Language(LanguagesEnum languagesEnum, string isoCode)
      {
         _languagesEnum = languagesEnum;
         this.IsoCode = isoCode;
      }

      public string IsoCode { get; }

      public override bool Equals(object? obj)
      {
         return Equals(obj as Language);
      }

      public bool Equals(Language? other)
      {
         return other is not null && _languagesEnum == other._languagesEnum;
      }

      public override int GetHashCode()
      {
         return _languagesEnum.GetHashCode();
      }

      public override string ToString()
      {
         return this.IsoCode;
      }

      public static bool operator ==(Language l1, Language l2)
      {
         return l1 is not null && l1.Equals(l2);
      }
      public static bool operator !=(Language l1, Language l2)
      {
         return !(l1 == l2);
      }
   }
}
