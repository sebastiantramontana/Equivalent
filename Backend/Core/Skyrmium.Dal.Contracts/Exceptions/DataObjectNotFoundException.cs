using System;

namespace Skyrmium.Dal.Contracts.Exceptions
{
   public class DataObjectNotFoundException : Exception
   {
      public DataObjectNotFoundException(string message) : base(message)
      {
      }
   }
}
