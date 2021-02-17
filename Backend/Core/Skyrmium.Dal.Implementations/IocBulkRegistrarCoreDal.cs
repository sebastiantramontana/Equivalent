using Skyrmium.Dal.Contracts;
using Skyrmium.Dal.Implementations.Queryables;
using Skyrmium.Dal.Implementations.Repositories;
using Skyrmium.Domain.Contracts.Queryables;
using Skyrmium.Domain.Contracts.Repositories;
using Skyrmium.Infrastructure.Contracts;

namespace Skyrmium.Dal.Implementations
{
   public class IocBulkRegistrarCoreDal : IIocBulkRegistrar
   {
      public void Register(IContainer container)
      {
         container.Register<IUnitOfWork, UnitOfWork>();
         container.Register(typeof(IRepository<>), typeof(MappedRepository<,>));
         container.Register(typeof(IOwnedRepository<>), typeof(MappedOwnedRepository<,>));
         container.Register(typeof(IQueryableEntity<>), typeof(QueryableEntity<,>));

      }
   }
}
