using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Skyrmium.Adapters.Contracts
{
   public interface IAdapter<T1, T2>
   {
      T2 Map([NotNull] T1 obj);
      T1 Map([NotNull] T2 obj);
      IEnumerable<T2> Map([NotNull] IEnumerable<T1> values);
      IEnumerable<T1> Map([NotNull] IEnumerable<T2> values);
   }
}
