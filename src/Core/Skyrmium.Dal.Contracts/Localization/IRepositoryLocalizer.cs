using Skyrmium.Localization.Contracts;

namespace Skyrmium.Dal.Contracts.Localization
{
   public interface IRepositoryLocalizer : ILocalizer
   {
      public string EntityAlreadyExists { get; }
      public string DataNotFound { get; }
   }
}
