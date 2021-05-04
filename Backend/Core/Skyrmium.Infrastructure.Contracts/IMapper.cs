using System.Collections.Generic;

namespace Skyrmium.Infrastructure.Contracts
{
   public interface IMapper<T1, T2>
      where T1 : class
      where T2 : class
   {
      T2 Map(T1 obj);
      T1 Map(T2 obj);
      IEnumerable<T2> Map(IEnumerable<T1> values);
      IEnumerable<T1> Map(IEnumerable<T2> values);
   }
}
