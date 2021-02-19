using AutoMapper;
using Skyrmium.Adapters.Implementations;
using Skyrmium.Equivalent.Measurement.Adapters.Dal;

namespace Skyrmium.Equivalent.Measurement.Adapters
{
   public class IocBulkRegistrarMeasurementAdapter : IocBulkRegistrarCoreAdapterBase
   {
      private readonly MapperConfiguration _mapperConfiguration;

      public IocBulkRegistrarMeasurementAdapter()
      {
         _mapperConfiguration = new MapperConfiguration(cfg =>
         {
            cfg.AddProfile<ConversionToConversionDao>();
            cfg.AddProfile<MeasureEquivalenceToMeasureEquivalenceDao>();
            cfg.AddProfile<MeasureToMeasureDao>();
            cfg.AddProfile<OrderedMeasureEquivalenceToDao>();

            cfg.AddProfile<ConversionToConversionDto>();
            cfg.AddProfile<MeasureEquivalenceToMeasureEquivalenceDto>();
            cfg.AddProfile<MeasureToMeasureDto>();
            cfg.AddProfile<OrderedMeasureEquivalenceToDto>();

         });
      }

      protected override MapperConfiguration GetMapperConfiguration()
      {
         _mapperConfiguration.CompileMappings();

         return _mapperConfiguration;
      }
   }
}
