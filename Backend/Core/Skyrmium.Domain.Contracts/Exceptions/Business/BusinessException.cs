using System;

namespace Skyrmium.Domain.Contracts.Exceptions.Business
{
   public class BusinessException<TKey, TValue> : Exception
      where TKey : Enum
      where TValue : Enum
   {
      public BusinessException(string title, IBusinessExceptionInfo<TKey, TValue> info)
      {
         this.Title = title;
         this.Info = info;
      }

      public string Title { get; }
      public IBusinessExceptionInfo<TKey, TValue> Info { get; }
   }
}
