using Skyrmium.Adapters.Contracts;
using Skyrmium.Infrastructure.Contracts;

namespace Skyrmium.Adapters.Implementations
{
   public class IocBulkRegistrarCoreAdapter : IIocBulkRegistrar
   {
      public void Register(IContainer container)
      {
         container.Register(typeof(IAdapter<,>), typeof(Adapter<,>));
         container.Register(typeof(IExpressionAdapter<,>), typeof(ExpressionAdapter<,>));

      }
   }
}
