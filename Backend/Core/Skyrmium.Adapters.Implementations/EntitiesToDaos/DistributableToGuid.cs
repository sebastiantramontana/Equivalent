using AutoMapper;
using Skyrmium.Domain.Contracts;
using Skyrmium.Domain.Implementations;
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
            .ConstructUsing(g => g.HasValue ? DistributableId.Instance(g.Value) : DistributableId.None);
      }
   }
}
