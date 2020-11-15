using System;
using System.Collections.Generic;

namespace Skyrmium.Domain.Entities.Contracts.Exceptions.Business
{
   public interface IBusinessExceptionInfo<TKey, TValue>
      where TKey : Enum
      where TValue : Enum
   {
      TKey Key { get; }
      IDictionary<TValue, object> Values { get; }
   }
}
