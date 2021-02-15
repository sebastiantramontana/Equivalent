using System;

namespace Skyrmium.Api.Contracts
{
   public interface IDto
   {
      Guid? DistributedId { get; set; }
   }
}
