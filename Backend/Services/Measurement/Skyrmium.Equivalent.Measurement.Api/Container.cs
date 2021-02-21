using Microsoft.Extensions.DependencyInjection;
using Skyrmium.Infrastructure.Contracts;
using System;

namespace Skyrmium.Equivalent.Measurement.Api
{
   internal class Container : IContainer
   {
      private readonly IServiceCollection _serviceCollection;

      public Container(IServiceCollection serviceCollection)
      {
         _serviceCollection = serviceCollection;
      }

      public void Register<TService, TImplementation>()
         where TService : class
         where TImplementation : class, TService
      {
         _serviceCollection.AddScoped<TService, TImplementation>();
      }

      public void Register<TService>(TService service) where TService : class
      {
         _serviceCollection.AddScoped((f) => service);
      }

      public void Register(Type serviceType, Type implementationType)
      {
         _serviceCollection.AddScoped(serviceType, implementationType);
      }
   }
}
