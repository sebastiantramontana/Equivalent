using System;

namespace Skyrmium.Infrastructure.Contracts
{
   public interface IContainer
   {
      void Register<TService, TImplementation>() 
         where TService : class 
         where TImplementation : class, TService;
      void Register<TService>(TService service) where TService : class;
      void Register(Type serviceType, Type implementationType);
   }
}
