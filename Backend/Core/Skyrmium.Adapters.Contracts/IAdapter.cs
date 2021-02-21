using System.Collections.Generic;

namespace Skyrmium.Adapters.Contracts
{
   public interface IAdapter<T1, T2>
   {
      T2 Map(T1 obj);
      T1 Map(T2 obj);
      IEnumerable<T2> Map(IEnumerable<T1> values);
      IEnumerable<T1> Map(IEnumerable<T2> values);
   }
}
