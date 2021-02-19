using Microsoft.EntityFrameworkCore;
using Skyrmium.Infrastructure.Contracts;

namespace Skyrmium.Equivalent.Measurement.Dal
{
   public class IocBulkRegistrarMeasurementDal : IIocBulkRegistrar
   {
      private readonly IConfiguration _configuration;

      public IocBulkRegistrarMeasurementDal(IConfiguration configuration)
      {
         _configuration = configuration;
      }

      public void Register(IContainer container)
      {
         container.Register<DbContext, MeasurementDbContext>(() => new MeasurementDbContext(_configuration.StringConnection));
      }
   }
}
