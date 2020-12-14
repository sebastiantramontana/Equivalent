using Skyrmium.Domain.Contracts;
using System;

namespace Skyrmium.Dal.Contracts.Daos
{
   public interface IDistributableDao : IDao
   {
      Guid DistributedId { get; set; }
   }
}
