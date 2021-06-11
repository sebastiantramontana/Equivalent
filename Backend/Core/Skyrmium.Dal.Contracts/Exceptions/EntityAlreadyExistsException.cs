using Skyrmium.Domain.Contracts.Entities;
using System;

namespace Skyrmium.Dal.Contracts.Exceptions
{
   public class EntityAlreadyExistsException : Exception
   {
      public EntityAlreadyExistsException(string message) : base(message)
      {
      }
   }
}
