using System;

namespace Skyrmium.Dal.Contracts.Daos
{
   public interface IDao
   {
      long Id { get; set; }
      Guid DistributedId { get; set; }
   }
}
