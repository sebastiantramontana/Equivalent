using System;
using System.Collections.Generic;

namespace Skyrmium.Domain.Contracts.Exceptions
{
   public interface IBusinessExceptionInfo<TKey, TValue>
      where TKey : Enum
      where TValue : Enum
   {
      TKey Key { get; }
      IDictionary<TValue, object> Values { get; }
   }
}
