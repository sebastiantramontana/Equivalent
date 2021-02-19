using System;

namespace Skyrmium.Infrastructure.Contracts
{
   public interface IContainer
   {
      void Register<TInterface, TService>() where TService : class, TInterface;
      void Register<TInterface>(TInterface service) where TInterface : class;
      void Register(Type interfaceType, Type implementation);
   }
}
