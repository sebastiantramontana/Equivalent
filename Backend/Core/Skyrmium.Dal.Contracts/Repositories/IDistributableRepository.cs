using Skyrmium.Domain.Contracts;
using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Dal.Contracts.Repositories
{
   public interface IDistributableRepository<TEntity> : IRepository<TEntity>
      where TEntity : IDistributableEntity
   {
      TEntity GetByDistributedId(IDistributableId distributedId);
   }
}
