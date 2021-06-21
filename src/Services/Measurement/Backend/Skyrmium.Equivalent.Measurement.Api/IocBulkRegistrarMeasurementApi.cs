using Skyrmium.Equivalent.Measurement.Api.Dtos;
using Skyrmium.Equivalent.Measurement.Api.EntityMapping;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Infrastructure.Contracts;

namespace Skyrmium.Equivalent.Measurement.Api
{
   public class IocBulkRegistrarMeasurementApi : IIocBulkRegistrar
   {
      public void Register(IContainer container)
      {
         container.Register<IMapper<Conversion, ConversionDto>, ConversionToConversionDto>();
         container.Register<IMapper<MeasureEquivalence, MeasureEquivalenceDto>, MeasureEquivalenceToMeasureEquivalenceDto>();
         container.Register<IMapper<Measure, MeasureDto>, MeasureToMeasureDto>();
         container.Register<IMapper<OrderedMeasureEquivalence, OrderedMeasureEquivalenceDto>, OrderedMeasureEquivalenceToDto>();
      }
   }
}
