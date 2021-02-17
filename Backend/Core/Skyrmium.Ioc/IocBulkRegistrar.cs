using Skyrmium.Adapters.Contracts;
using Skyrmium.Adapters.Implementations;
using Skyrmium.Dal.Contracts;
using Skyrmium.Dal.Implementations;
using Skyrmium.Dal.Implementations.Repositories;
using Skyrmium.Domain.Contracts.Repositories;
using Skyrmium.Infrastructure.Contracts;

namespace Skyrmium.Ioc
{
   public class IocBulkRegistrar : IIocBulkRegistrar
   {
      public void Register(IContainer container)
      {
         container.Register(typeof(IAdapter<,>), typeof(Adapter<,>));
         container.Register<IUnitOfWork, UnitOfWork>();
         container.Register(typeof(IRepository<>), typeof(MappedRepository<,>));
         //container.Register
      }
   }
}
