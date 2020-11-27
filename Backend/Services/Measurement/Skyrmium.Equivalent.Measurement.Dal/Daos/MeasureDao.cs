using Skyrmium.Dal.Contracts;
using System;

namespace Skyrmium.Equivalent.Measurement.Dal.Daos
{
   public class MeasureDao : IDao
   {
      public long Id { get; set; }
      public Guid DistributedId { get; set; }
      public string FullName { get; set; } = string.Empty;

      public string ShortName { get; set; } = string.Empty;
   }
}
