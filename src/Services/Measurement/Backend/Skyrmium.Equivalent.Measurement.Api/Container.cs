using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
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

      public void Register<TService>(Func<IServiceLocator, TService> serviceBuilder) where TService : class
      {
         _serviceCollection.AddScoped(sp => serviceBuilder(new ServiceLocator(sp)));
      }

      public void Register(Type type, Func<IServiceLocator, object> serviceBuilder)
      {
         _serviceCollection.AddScoped(type, sp => serviceBuilder(new ServiceLocator(sp)));
      }

      public void Register<TImplementation>() where TImplementation : class
      {
         _serviceCollection.AddScoped<TImplementation>();
      }

      public void RegisterTransient<TImplementation>() where TImplementation : class
      {
         _serviceCollection.AddTransient<TImplementation>();
      }
   }
}
