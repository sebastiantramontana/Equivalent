using Skyrmium.Dal.Contracts.Localization;
using Skyrmium.Localization.Abstractions;
using Skyrmium.Localization.Contracts;

namespace Skyrmium.Dal.Implementations.Localization
{
   public sealed class EnUsRepositoryLocalizer : LocalizerBase, IRepositoryLocalizer
   {
      public EnUsRepositoryLocalizer(ISupportedCultures supportedCultures) : base(supportedCultures.EnUS)
      {
      }

      public string EntityAlreadyExists { get; } = "Entity already exists";
      public string DataNotFound { get; } = "Data not found";
   }
}
