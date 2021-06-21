using Skyrmium.Dal.Contracts;
using Skyrmium.Dal.Contracts.Localization;
using Skyrmium.Dal.Implementations.Localization;
using Skyrmium.Infrastructure.Contracts;
using Skyrmium.Localization.Contracts;

namespace Skyrmium.Dal.Implementations
{
   public class IocBulkRegistrarCoreDal : IIocBulkRegistrar
   {
      public void Register(IContainer container)
      {
         container.Register<EnUsRepositoryLocalizer>();
         container.Register<EsEsRepositoryLocalizer>();
         container.Register<ILocalizerFactory<IRepositoryLocalizer>, RepositoryLocalizerFactory>();
         container.Register(locator => CreateLocalizer(locator));

         container.Register<IUnitOfWork, UnitOfWork>();
      }

      private static IRepositoryLocalizer CreateLocalizer(IServiceLocator locator)
      {
         var currentCulture = locator.Resolve<ICurrentCulture>();
         var localizerFactory = locator.Resolve<ILocalizerFactory<IRepositoryLocalizer>>();

         return localizerFactory.Create(currentCulture.Culture);
      }
   }
}
