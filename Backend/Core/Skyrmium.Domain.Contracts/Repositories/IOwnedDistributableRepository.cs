using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Domain.Contracts.Repositories
{
   public interface IOwnedDistributableRepository<TEntity> : IDistributableRepository<TEntity>, IOwnedRepository<TEntity>
      where TEntity : IOwnedDistributableEntity
   {
   }
}
