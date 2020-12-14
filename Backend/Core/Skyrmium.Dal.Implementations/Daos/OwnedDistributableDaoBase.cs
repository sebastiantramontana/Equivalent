using Skyrmium.Dal.Contracts.Daos;
using System;

namespace Skyrmium.Dal.Implementations.Daos
{
   public abstract class OwnedDistributableDaoBase : DistributableDaoBase, IOwnedDistributableDao
   {
      public Guid? OwnedBy { get; set; }
   }
}
