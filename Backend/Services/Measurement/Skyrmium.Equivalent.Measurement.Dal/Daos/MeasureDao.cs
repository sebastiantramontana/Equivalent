using Skyrmium.Dal.Implementations.Daos;

namespace Skyrmium.Equivalent.Measurement.Dal.Daos
{
   public class MeasureDao : OwnedDistributableDaoBase
   {
      public string FullName { get; set; } = string.Empty;
      public string ShortName { get; set; } = string.Empty;
   }
}
