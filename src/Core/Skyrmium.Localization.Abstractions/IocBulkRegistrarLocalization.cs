using Skyrmium.Infrastructure.Contracts;
using Skyrmium.Localization.Contracts;

namespace Skyrmium.Localization.Abstractions
{
   public class IocBulkRegistrarLocalization : IIocBulkRegistrar
   {
      public void Register(IContainer container)
      {
         container.Register<ISupportedCultures, SupportedCultures>();
         container.Register<ICurrentCulture, CurrentCulture>();
      }
   }
}
