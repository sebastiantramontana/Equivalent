using Skyrmium.Adapters.Contracts;
using Skyrmium.Equivalent.Measurement.Adapters.Dal;
using Skyrmium.Equivalent.Measurement.Api.Dtos;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Infrastructure.Contracts;

namespace Skyrmium.Equivalent.Measurement.Adapters
{
   public class IocBulkRegistrarMeasurementAdapter : IIocBulkRegistrar
   {
      public void Register(IContainer container)
      {
         container.Register<IAdapter<Conversion, ConversionDao>, ConversionToConversionDao>();
         container.Register<IAdapter<MeasureEquivalence, MeasureEquivalenceDao>, MeasureEquivalenceToMeasureEquivalenceDao>();
         container.Register<IAdapter<Measure, MeasureDao>, MeasureToMeasureDao>();
         container.Register<IAdapter<OrderedMeasureEquivalence, OrderedMeasureEquivalenceDao>, OrderedMeasureEquivalenceToDao>();

         container.Register<IAdapter<Conversion, ConversionDto>, ConversionToConversionDto>();
         container.Register<IAdapter<MeasureEquivalence, MeasureEquivalenceDto>, MeasureEquivalenceToMeasureEquivalenceDto>();
         container.Register<IAdapter<Measure, MeasureDto>, MeasureToMeasureDto>();
         container.Register<IAdapter<OrderedMeasureEquivalence, OrderedMeasureEquivalenceDto>, OrderedMeasureEquivalenceToDto>();
      }
   }
}
