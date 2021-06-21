using Skyrmium.Localization.Contracts;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities.Localization.MeasureEquivalence
{
   public interface IMeasureEquivalenceLocalizer : ILocalizer
   {
      string EquivalenceNotFound { get; }
      string InvalidEquivalence { get; }
      string EmptyMeasures { get; }
   }
}
