using System;

namespace Skyrmium.Infrastructure.Contracts
{
   public interface IServiceLocator
   {
      T Resolve<T>() where T : notnull;
      object Resolve(Type type);
   }
}
