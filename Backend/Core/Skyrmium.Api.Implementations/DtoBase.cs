﻿using Skyrmium.Api.Contracts;
using System;

namespace Skyrmium.Api.Implementations
{
   public abstract class DtoBase : IDto
   {
      public Guid DistributedId { get; set; }
   }
}
