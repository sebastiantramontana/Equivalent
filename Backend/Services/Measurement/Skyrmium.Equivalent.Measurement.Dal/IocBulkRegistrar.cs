using Microsoft.EntityFrameworkCore;
using Skyrmium.Dal.Contracts;
using Skyrmium.Dal.Implementations;
using Skyrmium.Dal.Implementations.Repositories;
using Skyrmium.Domain.Contracts.Repositories;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Infrastructure.Contracts;

namespace Skyrmium.Equivalent.Measurement.Dal
{
   public class IocBulkRegistrar : IIocBulkRegistrar
   {
      private readonly IConfiguration _configuration;

      public IocBulkRegistrar(IConfiguration configuration)
      {
         _configuration = configuration;
      }

      public void Register(IContaner container)
      {
         container.Register<IRepository<Measure>, MappedOwnedRepository<Measure, MeasureDao>>();
         container.Register<IRepository<MeasureEquivalence>, MappedOwnedRepository<MeasureEquivalence, MeasureEquivalenceDao>>();
         container.Register<DbContext, MeasurementDbContext>(() => new MeasurementDbContext(_configuration.StringConnection));
      }
   }
}
