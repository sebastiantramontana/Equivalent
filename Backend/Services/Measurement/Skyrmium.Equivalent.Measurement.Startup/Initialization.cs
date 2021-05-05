using Skyrmium.Infrastructure.Contracts;
using Skyrmium.Measurement.IoC;

namespace Skyrmium.Equivalent.Measurement.Startup
{
   public static class Initialization
   {
      public static void RegisterAll(IContainer container, IConfiguration configImplementation, IIocBulkRegistrar apiRegistrar)
      {
         var ioc = new IocBulkRegistrarMeasurement(configImplementation, apiRegistrar);
         ioc.Register(container);
      }
   }
}
