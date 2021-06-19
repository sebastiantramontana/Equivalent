using Skyrmium.Localization.Abstractions;
using Skyrmium.Localization.Contracts;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities.Localization.MeasureEquivalence
{
   public class EsEsMeasureEquivalenceLocalizer : LocalizerBase, IMeasureEquivalenceLocalizer
   {
      public EsEsMeasureEquivalenceLocalizer(ISupportedCultures supportedCultures) : base(supportedCultures.EsES)
      {
      }

      public string EquivalenceNotFound { get; } = "Equivalencia no encontrada";
      public string InvalidEquivalence { get; } = "Equivalencia Inv[alida";
      public string EmptyMeasures { get; } = "Las medidas no pueden estar vacías";
   }
}
