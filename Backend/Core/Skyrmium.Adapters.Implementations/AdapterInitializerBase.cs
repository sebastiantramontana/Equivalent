using Skyrmium.Adapters.Contracts;
using System.Collections.Generic;

namespace Skyrmium.Adapters.Implementations
{
   public abstract class AdapterInitializerBase : IAdapterInitializer
   {
      public void Initialize()
      {
         var configurators = GetAdapterConfigurators();

         foreach (var config in configurators)
         {
            config.Configure();
         }
      }

      protected abstract IEnumerable<IAdapterConfigurator> GetAdapterConfigurators();
   }
}
