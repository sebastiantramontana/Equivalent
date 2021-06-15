using Skyrmium.Dal.Contracts.Localization;
using Skyrmium.Localization.Abstractions;
using Skyrmium.Localization.Contracts;

namespace Skyrmium.Dal.Implementations.Localizations
{
   public abstract class EsEsRepositoryLocalizerBase : LocalizerBase, IRepositoryLocalizer
   {
      public EsEsRepositoryLocalizerBase() : base(SupportedLanguajes.EsES)
      {
      }

      public string EntityAlreadyExists { get; } = "La entidad ya existe";
      public string DataNotFound { get; } = "Dato no encontrado";
   }
}
