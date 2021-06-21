using Skyrmium.Localization.Abstractions;
using Skyrmium.Localization.Contracts;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities.Localization.Measure
{
   public class EsEsMeasureLocalizer : LocalizerBase, IMeasureLocalizer
   {
      public EsEsMeasureLocalizer(ISupportedCultures supportedCultures) : base(supportedCultures.EsES)
      {
      }

      public string EmptyFullName { get; } = "El nombre completo de la unidad de medida es requerido";
      public string InvalidMeasure { get; } = "Unidad de Medida Inválida";
   }
}
