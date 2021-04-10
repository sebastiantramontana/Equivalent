using AutoMapper;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Implementations.Entities;
using System;

namespace Skyrmium.Adapters.Implementations.EntitiesToDaos
{
   public class DistributableToGuid : Profile
   {
      public DistributableToGuid()
      {
         CreateMap<IDistributableId, Guid?>()
            .ConvertUsing(d => d.IsNone ? null : d.Value);

         CreateMap<IDistributableId, Guid>()
            .ConvertUsing(d => d.IsNone ? Guid.Empty : d.Value);

         CreateMap<Guid?, IDistributableId>()
            .ConvertUsing(g => g.HasValue && g.Value != Guid.Empty ? DistributableId.Instance(g.Value) : DistributableId.None);

         CreateMap<Guid, IDistributableId>()
            .ConvertUsing(g => g != Guid.Empty ? DistributableId.Instance(g) : DistributableId.None);

         CreateMap<Guid, Guid?>();
         CreateMap<Guid?, Guid>();
      }
   }
}
