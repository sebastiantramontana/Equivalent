using Skyrmium.Dal.Contracts.Localization;
using Skyrmium.Localization.Abstractions;

namespace Skyrmium.Dal.Implementations.Localization
{
   internal class RepositoryLocalizerFactory : LocalizerFactoryBase<IRepositoryLocalizer>
   {
      public RepositoryLocalizerFactory(EnUsRepositoryLocalizer enUs, EsEsRepositoryLocalizer esEs)
         : base(new IRepositoryLocalizer[]
         {
            enUs,
            esEs
         })
      {
      }
   }
}
