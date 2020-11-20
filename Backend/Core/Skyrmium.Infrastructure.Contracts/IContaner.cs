using System;

namespace Skyrmium.Infrastructure.Contracts
{
   public interface IContaner
   {
      void Register<TInterface, TService>() where TService : class, TInterface;
      void Register<TInterface, TService>(TService service) where TService : class, TInterface;
      void Register<TInterface, TService>(Func<TService> serviceFunc) where TService : class, TInterface;
      void Register(Type interfaceType, Type implementation);
      void Register(Type interfaceType, object service);
      void Register(Type interfaceType, Func<object> serviceFunc);
   }
}
