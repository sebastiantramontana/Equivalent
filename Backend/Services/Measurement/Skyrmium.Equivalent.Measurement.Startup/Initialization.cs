using Skyrmium.Equivalent.Measurement.Adapters;
using Skyrmium.Infrastructure.Contracts;
using Skyrmium.Measurement.IoC;
using System;

namespace Skyrmium.Equivalent.Measurement.Startup
{
   public static class Initialization
   {
      public static void Initialize(IContainer container, IConfiguration configuration, Action<Action> adapterInitializationAction)
      {
         var ioc = new IocBulkRegistrarMeasurement(configuration);
         ioc.Register(container);

         adapterInitializationAction(() => AdapterConfiguration.Configure());
      }
   }
}
