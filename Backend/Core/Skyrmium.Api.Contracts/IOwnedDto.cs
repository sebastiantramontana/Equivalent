using System;

namespace Skyrmium.Api.Contracts
{
   public interface IOwnedDto : IDto
   {
      Guid? OwnedBy { get; set; }
   }
}
