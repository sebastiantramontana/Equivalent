using Skyrmium.Dal.Contracts.Localization;
using Skyrmium.Localization.Abstractions;

namespace Skyrmium.Dal.Implementations.Localization
{
   public sealed class EsEsRepositoryLocalizer : LocalizerBase, IRepositoryLocalizer
   {
      public EsEsRepositoryLocalizer() : base(SupportedLanguages.EsES)
      {
      }

      public string EntityAlreadyExists { get; } = "La entidad ya existe";
      public string DataNotFound { get; } = "Dato no encontrado";
   }
}
