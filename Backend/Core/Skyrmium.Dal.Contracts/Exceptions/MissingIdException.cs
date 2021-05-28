using System;

namespace Skyrmium.Dal.Contracts.Exceptions
{
   public class MissingIdException : Exception
   {
      public MissingIdException(Guid id)
      {
         this.Id = id;
      }
      public Guid Id { get; }
   }
}
