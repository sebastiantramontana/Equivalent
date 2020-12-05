using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Dal.Contracts.Repositories
{
   public interface IOwnedDistributableRepository<TEntity> : IDistributableRepository<TEntity>, IOwnedRepository<TEntity>
      where TEntity : IOwnedDistributableEntity
   {
   }
}
