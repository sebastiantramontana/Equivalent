using AutoMapper;
using Skyrmium.Equivalent.Measurement.Adapters.Dal;

namespace Skyrmium.Equivalent.Measurement.Adapters
{
   public static class AdapterConfiguration
   {
      private static MapperConfiguration _mapperConfiguration;

      static AdapterConfiguration()
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

      public static void Configure()
      {
         _mapperConfiguration.CompileMappings();
      }
   }
}
