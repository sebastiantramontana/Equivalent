using Skyrmium.Localization.Abstractions;
using Skyrmium.Localization.Contracts;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities.Localization.Conversion
{
   public class EsEsConversionLocalizer : LocalizerBase, IConversionLocalizer
   {
      public EsEsConversionLocalizer() : base(Languages.esES)
      {
      }

      public string InvalidConversion { get; } = "Conversión Inválida";
      public string SerachedConversionNotFound { get; } = "Conversiión no encontrada";
      public string SerachedConversionNotFoundForGivenEquivalences { get; } = "No se encontró una conversión para las equivalencias dadas";

      public string BuildDuplicatedOrder(string conversionName)
      {
         return $"La conversión {conversionName} tiene distintas equivalencias en el mismo orden";
      }

      public string BuildUnorderedEquivalences(string conversionName)
      {
         return $"La conversión {conversionName} tiene equivalencias mal ordenadas. El origen de una equivalencia debe ser el mismo del destino de la equivalencia anterior.";
      }

      public string BuildConversionEmptyOfEquivalences(string conversionName)
      {
         return $"A la conversion {conversionName} le faltan las equivalencias";
      }
   }
}
