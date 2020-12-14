using System;

namespace Skyrmium.Dal.Contracts.Daos
{
   public interface IOwnedDao : IDao
   {
      Guid? OwnedBy { get; set; }
   }
}
