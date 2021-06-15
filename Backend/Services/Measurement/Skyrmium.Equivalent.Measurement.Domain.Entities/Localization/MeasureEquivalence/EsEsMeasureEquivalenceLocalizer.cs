using Skyrmium.Localization.Abstractions;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities.Localization.MeasureEquivalence
{
   internal class EsEsMeasureEquivalenceLocalizer : LocalizerBase, IMeasureEquivalenceLocalizer
   {
      public EsEsMeasureEquivalenceLocalizer() : base(SupportedLanguages.EsES)
      {
      }

      public string EquivalenceNotFound { get; } = "Equivalencia no encontrada";
      public string InvalidEquivalence { get; } = "Equivalencia Inv[alida";
      public string EmptyMeasures { get; } = "Las medidas no pueden estar vacías";
   }
}
