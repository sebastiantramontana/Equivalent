using Skyrmium.Adapters.Contracts;
using System.Collections.Generic;

namespace Skyrmium.Adapters.Implementations
{
   public abstract class AdapterInitializationBase : IAdapterInitialization
   {
      public void Initialize()
      {
         var initializer = GetAdapterInitializers();

         foreach (var init in initializer)
         {
            init.Initialize();
         }
      }

      protected abstract IEnumerable<IAdapterInitializer> GetAdapterInitializers();
   }
}
