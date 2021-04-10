using AutoMapper;
using Skyrmium.Adapters.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skyrmium.Adapters.Implementations
{
   internal class Adapter<T1, T2> : IAdapter<T1, T2>
   {
      public Adapter(IMapper mapper)
      {
         this.Mapper = mapper;
      }

      public T2 Map(T1 obj)
      {
         return Mapper.Map<T1, T2>(obj);
      }

      public T1 Map(T2 obj)
      {
         return Mapper.Map<T2, T1>(obj);
      }

      public IEnumerable<T2> Map(IEnumerable<T1> values)
      {
         return values.Select(v => Map(v));
      }

      public IEnumerable<T1> Map(IEnumerable<T2> values)
      {
         return values.Select(v => Map(v));
      }

      protected IMapper Mapper { get; }
   }
}
