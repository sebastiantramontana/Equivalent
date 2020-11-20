﻿using Skyrmium.Dal.Contracts;
using Skyrmium.Infrastructure.Contracts;

namespace Skyrmium.Dal.Implementations
{
   public class IocBulkRegistrar : IIocBulkRegistrar
   {
      public void Register(IContaner contaner)
      {
         contaner.Register<IUnitOfWork, UnitOfWork>();
         contaner.Register(typeof(IRepository<>), typeof(MappedRepository<,>));
      }
   }
}
