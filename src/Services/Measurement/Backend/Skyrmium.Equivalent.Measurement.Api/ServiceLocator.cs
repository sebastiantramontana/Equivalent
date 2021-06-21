using Microsoft.Extensions.DependencyInjection;
using Skyrmium.Infrastructure.Contracts;
using System;

namespace Skyrmium.Equivalent.Measurement.Api
{
   internal class ServiceLocator : IServiceLocator
   {
      private readonly IServiceProvider _serviceProvider;

      public ServiceLocator(IServiceProvider serviceProvider)
      {
         _serviceProvider = serviceProvider;
      }

      public T Resolve<T>() where T : notnull
      {
         return _serviceProvider.GetRequiredService<T>();
      }

      public object Resolve(Type type)
      {
         return _serviceProvider.GetRequiredService(type);
      }
   }
}
