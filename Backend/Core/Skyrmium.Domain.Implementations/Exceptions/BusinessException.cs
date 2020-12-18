using Skyrmium.Domain.Contracts.Exceptions;
using System;

namespace Skyrmium.Domain.Implementations.Exceptions
{
   public class BusinessException<TExceptionEnum, TExceptionValueEnum> : Exception, IBusinessException<TExceptionEnum, TExceptionValueEnum>
      where TExceptionEnum : Enum
      where TExceptionValueEnum : Enum
   {
      public BusinessException(string title, IBusinessExceptionInfo<TExceptionEnum, TExceptionValueEnum> info)
      {
         this.Title = title;
         this.Info = info;
      }

      public string Title { get; }
      public IBusinessExceptionInfo<TExceptionEnum, TExceptionValueEnum> Info { get; }

      public Exception ToException()
      {
         return this;
      }
   }
}
