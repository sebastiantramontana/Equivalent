using Skyrmium.Dal.Contracts.Localization;
using Skyrmium.Localization.Abstractions;
using Skyrmium.Localization.Contracts;

namespace Skyrmium.Dal.Implementations.Localization
{
   internal class RepositoryLocalizerFactory : LocalizerFactoryBase<IRepositoryLocalizer>
   {
      public RepositoryLocalizerFactory(ISupportedCultures supportedCultures)
         : base(new IRepositoryLocalizer[]
         {
            new EnUsRepositoryLocalizer(supportedCultures),
            new EsEsRepositoryLocalizer(supportedCultures)
         })
      {
      }
   }
}
