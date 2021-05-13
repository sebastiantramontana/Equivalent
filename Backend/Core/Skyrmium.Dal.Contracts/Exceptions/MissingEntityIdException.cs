using Skyrmium.Domain.Contracts.Entities;
using System;

namespace Skyrmium.Dal.Contracts.Exceptions
{
   public class MissingEntityIdException : Exception
   {
      public MissingEntityIdException(IEntity entity)
      {
         this.Entity = entity;
      }

      public IEntity Entity { get; }
   }
}
