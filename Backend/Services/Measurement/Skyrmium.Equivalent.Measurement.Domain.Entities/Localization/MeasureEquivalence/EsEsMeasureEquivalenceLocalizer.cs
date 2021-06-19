using Skyrmium.Localization.Abstractions;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities.Localization.MeasureEquivalence
{
   public class EsEsMeasureEquivalenceLocalizer : LocalizerBase, IMeasureEquivalenceLocalizer
   {
      public EsEsMeasureEquivalenceLocalizer() : base(SupportedCultures.EsES)
      {
      }

      public string EquivalenceNotFound { get; } = "Equivalencia no encontrada";
      public string InvalidEquivalence { get; } = "Equivalencia Inv[alida";
      public string EmptyMeasures { get; } = "Las medidas no pueden estar vacías";
   }
}
