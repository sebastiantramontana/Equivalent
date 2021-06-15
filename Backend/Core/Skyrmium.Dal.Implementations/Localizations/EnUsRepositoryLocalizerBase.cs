using Skyrmium.Dal.Contracts.Localization;
using Skyrmium.Localization.Abstractions;
using Skyrmium.Localization.Contracts;

namespace Skyrmium.Dal.Implementations.Localizations
{
   public abstract class EnUsRepositoryLocalizerBase : LocalizerBase, IRepositoryLocalizer
   {
      public EnUsRepositoryLocalizerBase() : base(SupportedLanguajes.EnUS)
      {
      }

      public string EntityAlreadyExists { get; } = "Entity already exists";
      public string DataNotFound { get; } = "Data not found";
   }
}
