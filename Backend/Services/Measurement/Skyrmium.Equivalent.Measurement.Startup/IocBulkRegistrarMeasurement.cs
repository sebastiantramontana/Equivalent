using Skyrmium.Equivalent.Measurement.Dal;
using Skyrmium.Equivalent.Measurement.Domain.Services.Implementations;
using Skyrmium.Infrastructure.Contracts;
using Skyrmium.Ioc;
using System.Collections.Generic;

namespace Skyrmium.Measurement.IoC
{
   internal class IocBulkRegistrarMeasurement : IIocBulkRegistrar
   {
      private readonly IConfiguration _configuration;

      internal IocBulkRegistrarMeasurement(IConfiguration configuration)
      {
         _configuration = configuration;
      }

      public void Register(IContainer container)
      {
         var registrars = GetRegistrars();

         foreach (var registrar in registrars)
            registrar.Register(container);

         RegisterDomain(container);
      }

      private IEnumerable<IIocBulkRegistrar> GetRegistrars()
      {
         return new IIocBulkRegistrar[]
         {
            new IocBulkRegistrarCore(),
            new IocBulkRegistrarMeasurementDal(_configuration)
         };
      }

      private void RegisterDomain(IContainer container)
      {
         var iocDomain = new IocMeasurementDomainServices();
         
         foreach(var pair in iocDomain.TypePairs)
         {
            container.Register(pair.Interfaz, pair.Implementation);
         }
      }
   }
}
