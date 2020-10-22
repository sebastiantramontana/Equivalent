using System;

namespace Skyrmium.DomainModel.Entities.Contracts
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
