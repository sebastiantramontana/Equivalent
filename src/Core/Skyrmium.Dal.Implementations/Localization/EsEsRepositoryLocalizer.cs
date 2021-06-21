using Skyrmium.Dal.Contracts.Localization;
using Skyrmium.Localization.Abstractions;
using Skyrmium.Localization.Contracts;

namespace Skyrmium.Dal.Implementations.Localization
{
   public sealed class EsEsRepositoryLocalizer : LocalizerBase, IRepositoryLocalizer
   {
      public EsEsRepositoryLocalizer(ISupportedCultures supportedCultures) : base(supportedCultures.EsES)
      {
      }

      public string EntityAlreadyExists { get; } = "La entidad ya existe";
      public string DataNotFound { get; } = "Dato no encontrado";
   }
}
