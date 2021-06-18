using System;
using Microsoft.Extensions.DependencyInjection;
using Skyrmium.Infrastructure.Contracts;

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

      public void Register<TService, TImplementation>(TImplementation implementation)
         where TService : class
         where TImplementation : class, TService
      {
         _serviceCollection.AddScoped<TService, TImplementation>(provider => implementation);
      }

      public void Register<TService>(TService service) where TService : class
      {
         _serviceCollection.AddScoped((f) => service);
      }

      public void Register(Type serviceType, Type implementationType)
      {
         _serviceCollection.AddScoped(serviceType, implementationType);
      }

      public void Register<TService>(Func<IServiceProvider, TService> serviceBuilder) where TService : class
      {
         _serviceCollection.AddScoped(serviceBuilder);
      }

      public void Register(Type type, Func<IServiceProvider, object> serviceBuilder)
      {
         _serviceCollection.AddScoped(type, serviceBuilder);
      }

      public void RegisterTransient<TService, TImplementation>()
         where TService : class
         where TImplementation : class, TService
      {
         _serviceCollection.AddTransient<TService, TImplementation>();
      }
   }
}
