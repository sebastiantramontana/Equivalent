using Skyrmium.Dal.Contracts.Daos;
using System;

namespace Skyrmium.Dal.Implementations.Daos
{
   public abstract class OwnedDaoBase : DaoBase, IOwnedDao
   {
      public Guid? OwnedBy { get; set; }
   }
}
