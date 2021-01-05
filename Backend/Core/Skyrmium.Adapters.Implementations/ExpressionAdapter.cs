using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Skyrmium.Adapters.Contracts;
using System;
using System.Linq.Expressions;

namespace Skyrmium.Adapters.Implementations
{
   public class ExpressionAdapter<T1, T2> : Adapter<T1, T2>, IExpressionAdapter<T1, T2>
   {
      public ExpressionAdapter(IMapper mapper) : base(mapper)
      {
      }

      public Expression<Func<T2, T>> Map<T>(Expression<Func<T1, T>> condition)
      {
         return this.Mapper.MapExpression<Expression<Func<T1, T>>, Expression<Func<T2, T>>>(condition);
      }
   }
}
