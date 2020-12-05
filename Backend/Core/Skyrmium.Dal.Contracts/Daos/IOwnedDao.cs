using Skyrmium.Domain.Contracts;

namespace Skyrmium.Dal.Contracts.Daos
{
   public interface IOwnedDao : IDao
   {
      IDistributableId? OwnedBy { get; set; }
   }
}
