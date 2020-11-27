using System;

namespace Skyrmium.Dal.Contracts
{
   public interface IDao
   {
      long Id { get; set; }
      Guid DistributedId { get; set; }
   }
}
