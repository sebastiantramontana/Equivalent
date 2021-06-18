using Microsoft.Extensions.DependencyInjection;
using Skyrmium.Dal.Contracts;
using Skyrmium.Dal.Contracts.Localization;
using Skyrmium.Dal.Implementations.Localization;
using Skyrmium.Infrastructure.Contracts;
using Skyrmium.Localization.Contracts;
using System;

namespace Skyrmium.Dal.Implementations
{
   public class IocBulkRegistrarCoreDal : IIocBulkRegistrar
   {
      public void Register(IContainer container)
      {
         container.Register<IUnitOfWork, UnitOfWork>();
         container.Register(sp => CreateLocalizer(sp.GetRequiredService<CulturesEnum>()));
      }

      private static IRepositoryLocalizer CreateLocalizer(CulturesEnum language)
      {
         IRepositoryLocalizer repositoryLocalizer = language switch
         {
            CulturesEnum.enUS => new EnUsRepositoryLocalizer(),
            CulturesEnum.esES => new EsEsRepositoryLocalizer(),
            _ => throw new NotImplementedException($"Language {language} not implemented"),
         };
         return repositoryLocalizer;
      }
   }
}
