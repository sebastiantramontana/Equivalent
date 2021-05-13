using Skyrmium.Domain.Contracts.Entities;
using System;

namespace Skyrmium.Dal.Contracts.Exceptions
{
   public class EntityAlreadyHasIdException : Exception
   {
      public EntityAlreadyHasIdException(IEntity entity)
      {
         this.Entity = entity;
      }

      public IEntity Entity { get; }
   }
}
