using Skyrmium.Dal.Contracts.Localization;
using Skyrmium.Localization.Abstractions;

namespace Skyrmium.Dal.Implementations.Localization
{
   public sealed class EnUsRepositoryLocalizer : LocalizerBase, IRepositoryLocalizer
   {
      public EnUsRepositoryLocalizer() : base(SupportedLanguages.EnUS)
      {
      }

      public string EntityAlreadyExists { get; } = "Entity already exists";
      public string DataNotFound { get; } = "Data not found";
   }
}
