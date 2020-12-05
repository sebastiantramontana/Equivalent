using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Domain.Services.Contracts
{
   public interface IOwnedDistributableCrudService<TEntity> : IDistributableCrudService<TEntity>, IOwnedCrudService<TEntity>
      where TEntity : IOwnedDistributableEntity
   {
   }
}
