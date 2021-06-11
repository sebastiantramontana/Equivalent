using System;

namespace Skyrmium.Domain.Contracts.Exceptions
{
   public class BusinessException : Exception
   {
      public BusinessException(string title, string message) : base(message)
      {
         this.Title = title;
      }

      public string Title { get; }
   }
}
