using System;

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
      void Register<TImplementation>() where TImplementation : class;
      void Register<TService>(Func<IServiceProvider, TService> serviceBuilder) where TService : class;
      void Register(Type serviceType, Type implementationType);
      void Register(Type type, Func<IServiceProvider, object> serviceBuilder);
      void RegisterTransient<TImplementation>() where TImplementation : class;
   }
}
