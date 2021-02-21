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

         container.Register(typeof(IOwnedRepository<Conversion>), typeof(MappedOwnedRepository<Conversion, ConversionDao>));
         container.Register(typeof(IOwnedRepository<Measure>), typeof(MappedOwnedRepository<Measure, MeasureDao>));
         container.Register(typeof(IOwnedRepository<MeasureEquivalence>), typeof(MappedOwnedRepository<MeasureEquivalence, MeasureEquivalenceDao>));

         container.Register(typeof(IQueryableEntity<Conversion>), typeof(QueryableEntity<Conversion, ConversionDao>));
         container.Register(typeof(IQueryableEntity<Measure>), typeof(QueryableEntity<Measure, MeasureDao>));
         container.Register(typeof(IQueryableEntity<MeasureEquivalence>), typeof(QueryableEntity<MeasureEquivalence, MeasureEquivalenceDao>));
      }
   }
}
