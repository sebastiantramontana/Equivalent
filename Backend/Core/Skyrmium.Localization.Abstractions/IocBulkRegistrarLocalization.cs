using Skyrmium.Infrastructure.Contracts;

namespace Skyrmium.Localization.Abstractions
{
   public class IocBulkRegistrarLocalization : IIocBulkRegistrar
   {
      public void Register(IContainer container)
      {
         container.Register(SupportedCultures.EnUS);
      }
   }
}
