using Microsoft.EntityFrameworkCore;
using Skyrmium.Dal.Implementations.Queryables;
using Skyrmium.Dal.Implementations.Repositories;
using Skyrmium.Domain.Contracts.Queryables;
using Skyrmium.Domain.Contracts.Repositories;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Infrastructure.Contracts;

namespace Skyrmium.Equivalent.Measurement.Dal
{
   public class IocBulkRegistrarMeasurementDal : IIocBulkRegistrar
   {
      public void Register(IContainer container)
      {
         container.Register<DbContext, MeasurementDbContext>();

         container.Register<IOwnedRepository<Conversion>, MappedOwnedRepository<Conversion, ConversionDao>>();
         container.Register<IOwnedRepository<Measure>, MappedOwnedRepository<Measure, MeasureDao>>();
         container.Register<IOwnedRepository<MeasureEquivalence>, MappedOwnedRepository<MeasureEquivalence, MeasureEquivalenceDao>>();

         container.RegisterTransient<IQueryableEntity<Conversion>, QueryableEntity<Conversion, ConversionDao>>();
         container.RegisterTransient<IQueryableEntity<Measure>, QueryableEntity<Measure, MeasureDao>>();
         container.RegisterTransient<IQueryableEntity<MeasureEquivalence>, QueryableEntity<MeasureEquivalence, MeasureEquivalenceDao>>();
      }
   }
}
