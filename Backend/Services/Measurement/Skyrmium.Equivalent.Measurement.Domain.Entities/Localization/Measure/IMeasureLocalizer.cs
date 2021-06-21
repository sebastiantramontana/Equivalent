using Skyrmium.Localization.Contracts;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities.Localization.Measure
{
   public interface IMeasureLocalizer : ILocalizer
   {
      string InvalidMeasure { get; }
      string EmptyFullName { get; }
   }
}
