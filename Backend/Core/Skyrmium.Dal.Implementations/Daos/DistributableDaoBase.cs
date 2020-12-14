using Skyrmium.Dal.Contracts.Daos;
using System;

namespace Skyrmium.Dal.Implementations.Daos
{
   public abstract class DistributableDaoBase : DaoBase, IDistributableDao
   {
      public Guid DistributedId { get; set; } = Guid.Empty;
   }
}
