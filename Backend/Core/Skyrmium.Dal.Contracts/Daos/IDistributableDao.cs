using Skyrmium.Domain.Contracts;

namespace Skyrmium.Dal.Contracts.Daos
{
   public interface IDistributableDao : IDao
   {
      IDistributableId DistributedId { get; set; }
   }
}
