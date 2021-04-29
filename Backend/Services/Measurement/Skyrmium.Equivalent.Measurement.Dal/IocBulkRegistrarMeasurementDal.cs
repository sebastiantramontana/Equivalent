using Microsoft.EntityFrameworkCore;
using Skyrmium.Dal.Implementations.Repositories;
using Skyrmium.Domain.Contracts.Repositories;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Dal.Repositories;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Infrastructure.Contracts;

namespace Skyrmium.Equivalent.Measurement.Dal
{
   public class IocBulkRegistrarMeasurementDal : IIocBulkRegistrar
   {
      public void Register(IContainer container)
      {
         container.Register<DbContext, MeasurementDbContext>();

         container.Register<IOwnedRepository<Conversion>, OwnedRepository<Conversion, ConversionDao>>();
         container.Register<IOwnedRepository<Measure>, OwnedRepository<Measure, MeasureDao>>();
         container.Register<IRepository<Measure>, OwnedRepository<Measure, MeasureDao>>();
         container.Register<IMeasureEquivalenceRepository, MeasureEquivalenceRepository>();
         container.Register<IConversionRepository, ConversionRepository>();
      }
   }
}
