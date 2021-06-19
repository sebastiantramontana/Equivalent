using Microsoft.EntityFrameworkCore;
using Skyrmium.Dal.Contracts;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Dal.EntityMapping;
using Skyrmium.Equivalent.Measurement.Dal.Repositories;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts.Repositories;
using Skyrmium.Infrastructure.Contracts;

namespace Skyrmium.Equivalent.Measurement.Dal
{
   public class IocBulkRegistrarMeasurementDal : IIocBulkRegistrar
   {
      public void Register(IContainer container)
      {
         container.Register<IDataAccess, MeasurementDbContext>();
         container.Register((sp) => (DbContext)sp.GetService(typeof(IDataAccess))!);

         container.Register<IMeasureRepository, MeasureRepository>();
         container.Register<IMeasureEquivalenceRepository, MeasureEquivalenceRepository>();
         container.Register<IConversionRepository, ConversionRepository>();

         container.Register<IMapper<Conversion, ConversionDao>, ConversionToConversionDao>();
         container.Register<IMapper<MeasureEquivalence, MeasureEquivalenceDao>, MeasureEquivalenceToMeasureEquivalenceDao>();
         container.Register<IMapper<Measure, MeasureDao>, MeasureToMeasureDao>();
         container.Register<IMapper<OrderedMeasureEquivalence, OrderedMeasureEquivalenceDao>, OrderedMeasureEquivalenceToDao>();
      }
   }
}
