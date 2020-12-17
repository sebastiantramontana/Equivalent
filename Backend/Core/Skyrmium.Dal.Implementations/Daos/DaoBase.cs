using Skyrmium.Dal.Contracts.Daos;
using System;

namespace Skyrmium.Dal.Implementations.Daos
{
   public abstract class DaoBase : IDao
   {
      public long Id { get; set; }
      public Guid DistributedId { get; set; } = Guid.Empty;
   }
}
