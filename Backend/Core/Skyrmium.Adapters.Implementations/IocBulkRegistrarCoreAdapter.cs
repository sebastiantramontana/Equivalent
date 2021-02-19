using AutoMapper;
using Skyrmium.Adapters.Contracts;
using Skyrmium.Infrastructure.Contracts;

namespace Skyrmium.Adapters.Implementations
{
   public abstract class IocBulkRegistrarCoreAdapterBase : IIocBulkRegistrar
   {
      public void Register(IContainer container)
      {
         container.Register<IMapper>(new Mapper(GetMapperConfiguration()));
         container.Register(typeof(IAdapter<,>), typeof(Adapter<,>));
         container.Register(typeof(IExpressionAdapter<,>), typeof(ExpressionAdapter<,>));
      }

      protected abstract MapperConfiguration GetMapperConfiguration();
   }
}
