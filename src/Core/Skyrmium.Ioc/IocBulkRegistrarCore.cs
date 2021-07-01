﻿using Skyrmium.Api.Implementations;
using Skyrmium.Dal.Implementations;
using Skyrmium.Infrastructure.Contracts;
using Skyrmium.Localization.Abstractions;
using System.Collections.Generic;

namespace Skyrmium.Ioc
{
   public class IocBulkRegistrarCore : IIocBulkRegistrar
   {
      public void Register(IContainer container)
      {
         var registrars = GetCoreRegistrars();

         foreach (var reg in registrars)
            reg.Register(container);
      }

      private static IEnumerable<IIocBulkRegistrar> GetCoreRegistrars()
      {
         return new IIocBulkRegistrar[] {
            new IocBulkRegistrarCoreDal(),
            new IocBulkRegistrarCoreApi(),
            new IocBulkRegistrarLocalization()
         };
      }
   }
}