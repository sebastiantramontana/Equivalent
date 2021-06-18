using Skyrmium.Equivalent.Measurement.Dal;
using Skyrmium.Equivalent.Measurement.Domain.Services.Implementations;
using Skyrmium.Infrastructure.Contracts;
using Skyrmium.Ioc;
using Skyrmium.Localization.Contracts;
using System.Collections.Generic;

namespace Skyrmium.Measurement.IoC
{
   internal class IocBulkRegistrarMeasurement : IIocBulkRegistrar
   {
      private readonly IConfiguration _configImplementation;
      private readonly IIocBulkRegistrar _apiRegistrar;

      internal IocBulkRegistrarMeasurement(IConfiguration configImplementation, IIocBulkRegistrar apiRegistrar)
      {
         _configImplementation = configImplementation;
         _apiRegistrar = apiRegistrar;
      }

      public void Register(IContainer container)
      {
         container.Register(container);

         var registrars = GetRegistrars();

         foreach (var registrar in registrars)
            registrar.Register(container);

         RegisterDomain(container);

         container.Register(_configImplementation);
      }

      private IEnumerable<IIocBulkRegistrar> GetRegistrars()
      {
         return new IIocBulkRegistrar[]
         {
            new IocBulkRegistrarCore(),
            new IocBulkRegistrarMeasurementDal(),
            _apiRegistrar
         };
      }

      private static void RegisterDomain(IContainer container)
      {
         foreach (var (Interfaz, Implementation) in IocMeasurementDomainServices.TypePairs)
         {
            container.Register(Interfaz, Implementation);
         }

         foreach (var localizerBuilders in IocMeasurementDomainServices.CreateLocalizerBuilders())
         {
            container.Register(localizerBuilders.Type, localizerBuilders.Builder);
         }
      }
   }
}
