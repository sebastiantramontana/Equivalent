using Skyrmium.Dal.Contracts.Daos;
using Skyrmium.Domain.Contracts;
using Skyrmium.Domain.Implementations;

namespace Skyrmium.Equivalent.Measurement.Dal.Daos
{
   public class MeasureDao : IOwnedDistributableDao
   {
      public long Id { get; set; }
      public string FullName { get; set; } = string.Empty;
      public string ShortName { get; set; } = string.Empty;
      public IDistributableId DistributedId { get; set; } = DistributableId.None;
      public IDistributableId? OwnedBy { get; set; }
   }
}
