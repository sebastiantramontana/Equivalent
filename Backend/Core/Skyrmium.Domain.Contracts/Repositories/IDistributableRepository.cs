using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Domain.Contracts.Repositories
{
   public interface IDistributableRepository<TEntity> : IRepository<TEntity>
      where TEntity : IDistributableEntity
   {
      TEntity GetByDistributedId(IDistributableId distributedId);
   }
}
