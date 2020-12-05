using Skyrmium.Domain.Contracts;
using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Domain.Services.Contracts
{
   public interface IDistributableCrudService<TEntity> : ICrudService<TEntity>
      where TEntity : IDistributableEntity
   {
      TEntity GetByDistributedId(IDistributableId distributableId);
   }
}
