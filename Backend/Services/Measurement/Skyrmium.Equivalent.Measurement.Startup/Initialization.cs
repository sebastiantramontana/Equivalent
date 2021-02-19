using Skyrmium.Infrastructure.Contracts;
using Skyrmium.Measurement.IoC;

namespace Skyrmium.Equivalent.Measurement.Startup
{
   public static class Initialization
   {
      public static void Register(IContainer container, IConfiguration configImplementation)
      {
         var ioc = new IocBulkRegistrarMeasurement(configImplementation);
         ioc.Register(container);
      }
   }
}
