using System;
using System.Linq.Expressions;

namespace Skyrmium.Infrastructure.Contracts
{
   public interface IAdapter<T1, T2>
   {
      T2 Map(T1 obj);
      T1 Map(T2 obj);
   }
}
