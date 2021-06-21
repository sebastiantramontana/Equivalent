using Skyrmium.Api.Contracts;
using System;

namespace Skyrmium.Api.Implementations
{
   public abstract class OwnedDtoBase : DtoBase, IOwnedDto
   {
      public Guid OwnedBy { get; set; }
   }
}
