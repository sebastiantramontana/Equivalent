using Skyrmium.Localization.Abstractions;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities.Localization.MeasureEquivalence
{
   public class EnUsMeasureEquivalenceLocalizer : LocalizerBase, IMeasureEquivalenceLocalizer
   {
      public EnUsMeasureEquivalenceLocalizer() : base(SupportedCultures.EnUS)
      {
      }

      public string EquivalenceNotFound { get; } = "Equivalence not found";
      public string InvalidEquivalence { get; } = "Invalid Equivalence";
      public string EmptyMeasures { get; } = "Measures cannot be empty";
   }
}
