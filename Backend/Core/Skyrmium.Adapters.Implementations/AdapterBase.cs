using AutoMapper;
using Skyrmium.Adapters.Contracts;

namespace Skyrmium.Adapters.Implementations
{
   public abstract class AdapterBase<T1, T2> : IAdapter<T1, T2>
   {
      protected AdapterBase(IMapper mapper)
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
