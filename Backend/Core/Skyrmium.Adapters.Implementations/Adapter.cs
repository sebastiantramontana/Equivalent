using AutoMapper;
using Skyrmium.Adapters.Contracts;

namespace Skyrmium.Adapters.Implementations
{
   public class Adapter<T1, T2> : IAdapter<T1, T2>
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

      protected IMapper Mapper { get; }
   }
}
