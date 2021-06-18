using System;
using System.Collections.Generic;

namespace Skyrmium.Infrastructure.Contracts
{
   public interface IContainer
   {
      void Register<TService, TImplementation>()
         where TService : class
         where TImplementation : class, TService;

      void Register<TService, TImplementation>(TImplementation implementation)
         where TService : class
         where TImplementation : class, TService;

      void Register<TService>(TService service) where TService : class;
      void Register<TService>(Func<IServiceProvider, TService> serviceBuilder) where TService : class;
      void Register(Type serviceType, Type implementationType);
      void Register(Type type, Func<IServiceProvider, object> serviceBuilder);
      void RegisterTransient<TService, TImplementation>()
         where TService : class
         where TImplementation : class, TService;
   }
}
