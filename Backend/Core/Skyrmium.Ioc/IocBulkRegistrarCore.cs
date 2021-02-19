using Skyrmium.Adapters.Implementations;
using Skyrmium.Dal.Implementations;
using Skyrmium.Infrastructure.Contracts;
using System.Collections.Generic;

namespace Skyrmium.Ioc
{
   public class IocBulkRegistrarCore : IIocBulkRegistrar
   {
      public void Register(IContainer container)
      {
         var registrars = GetCoreRegistrars();

         foreach (var reg in registrars)
            reg.Register(container);
      }

      private IEnumerable<IIocBulkRegistrar> GetCoreRegistrars()
      {
         return new IIocBulkRegistrar[] {
            new IocBulkRegistrarCoreDal()
         };
      }
   }
}
