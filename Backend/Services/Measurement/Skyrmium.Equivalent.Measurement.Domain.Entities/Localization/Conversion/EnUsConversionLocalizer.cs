using Skyrmium.Localization.Abstractions;
using Skyrmium.Localization.Contracts;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities.Localization.Conversion
{
   public class EnUsConversionLocalizer : LocalizerBase, IConversionLocalizer
   {
      public EnUsConversionLocalizer() : base(Languages.enUS)
      {
      }

      public string InvalidConversion { get; } = "Invalid Conversion";
      public string SerachedConversionNotFound { get; } = "Searched conversion not found";
      public string SerachedConversionNotFoundForGivenEquivalences { get; } = "Conversion not found for the given equivalences";

      public string BuildDuplicatedOrder(string conversionName)
      {
         return $"Conversion {conversionName} has different equivalences in the same order";
      }

      public string BuildConversionEmptyOfEquivalences(string conversionName)
      {
         return $"Conversion {conversionName} is empty of equivalences";
      }

      public string BuildUnorderedEquivalences(string conversionName)
      {
         return $"Conversion {conversionName} has unordered equivalences. The equivalence source must to be the previous destination";
      }
   }
}
