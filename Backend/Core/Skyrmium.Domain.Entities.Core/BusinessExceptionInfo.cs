using Skyrmium.Domain.Entities.Contracts.Exceptions.Business;
using System;
using System.Collections.Generic;

namespace Skyrmium.Domain.Entities.Core
{
   public class BusinessExceptionInfo<TKey, TValue> : IBusinessExceptionInfo<TKey, TValue>
      where TKey : Enum
      where TValue : Enum
   {
      public BusinessExceptionInfo(TKey key, IDictionary<TValue, object> values)
      {
         this.Key = key;
         this.Values = values;
      }

      public TKey Key { get; }
      public IDictionary<TValue, object> Values { get; }
   }
}
