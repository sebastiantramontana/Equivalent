using System.Collections.Generic;
using System.Linq;

namespace Skyrmium.Infrastructure.Contracts
{
   public abstract class MapperBase<T1, T2> : IMapper<T1, T2>
      where T1 : class
      where T2 : class
   {
      public abstract T2 Map(T1 obj);
      public abstract T1 Map(T2 obj);


      public IEnumerable<T2> Map(IEnumerable<T1> values)
      {
         return values.Select(v => Map(v));
      }

      public IEnumerable<T1> Map(IEnumerable<T2> values)
      {
         return values.Select(v => Map(v));
      }
   }
}
