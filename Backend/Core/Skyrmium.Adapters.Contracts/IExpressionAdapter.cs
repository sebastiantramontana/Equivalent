using System;
using System.Linq.Expressions;

namespace Skyrmium.Adapters.Contracts
{
   public interface IExpressionAdapter<T1, T2> : IAdapter<T1, T2>
   {
      Expression<Func<T2, T>> Map<T>(Expression<Func<T1, T>> expression);
   }
}
