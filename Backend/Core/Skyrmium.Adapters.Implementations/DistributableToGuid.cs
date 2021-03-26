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
         CreateMap<IDistributableId, Guid?>(MemberList.None)
            .ConstructUsing(d => d.IsNone ? null : d.Value);

         CreateMap<Guid?, IDistributableId>(MemberList.None)
            .ConstructUsing(g => g.HasValue && g.Value != Guid.Empty ? DistributableId.Instance(g.Value) : DistributableId.None);
      }
   }
}
