using Skyrmium.Localization.Abstractions;
using Skyrmium.Localization.Contracts;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities.Localization.Measure
{
   public class EnUsMeasureLocalizer : LocalizerBase, IMeasureLocalizer
   {
      public EnUsMeasureLocalizer(ISupportedCultures supportedCultures) : base(supportedCultures.EnUS)
      {
      }

      public string EmptyFullName { get; } = "Measure's fullname is required";
      public string InvalidMeasure { get; } = "Invalid Measure";
   }
}
