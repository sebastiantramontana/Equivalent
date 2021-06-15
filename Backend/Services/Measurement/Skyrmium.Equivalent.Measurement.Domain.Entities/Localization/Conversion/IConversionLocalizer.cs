namespace Skyrmium.Equivalent.Measurement.Domain.Entities.Localization.Conversion
{
   public interface IConversionLocalizer
   {
      string InvalidConversion { get; }
      string SerachedConversionNotFound { get; }
      string SerachedConversionNotFoundForGivenEquivalences { get; }
      string BuildDuplicatedOrder(string conversionName);
      string BuildUnorderedEquivalences(string conversionName);
      string BuildConversionEmptyOfEquivalences(string conversionName);
   }
}
