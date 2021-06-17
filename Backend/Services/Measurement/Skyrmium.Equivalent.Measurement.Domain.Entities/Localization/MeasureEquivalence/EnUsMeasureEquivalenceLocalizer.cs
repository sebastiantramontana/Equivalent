using Skyrmium.Localization.Abstractions;
using Skyrmium.Localization.Contracts;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities.Localization.MeasureEquivalence
{
   internal class EnUsMeasureEquivalenceLocalizer : LocalizerBase, IMeasureEquivalenceLocalizer
   {
      public EnUsMeasureEquivalenceLocalizer() : base(Languages.enUS)
      {
      }

      public string EquivalenceNotFound { get; } = "Equivalence not found";
      public string InvalidEquivalence { get; } = "Invalid Equivalence";
      public string EmptyMeasures { get; } = "Measures cannot be empty";
   }
}
