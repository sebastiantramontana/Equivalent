using Skyrmium.Domain.Contracts;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Contracts.Repositories;
using Skyrmium.Domain.Services.Contracts;

namespace Skyrmium.Domain.Services.Implementations
{
   public abstract class DistributableCrudServiceBase<TEntity> : CrudServiceBase<IDistributableRepository<TEntity>, TEntity>, IDistributableCrudService<TEntity>
      where TEntity : IDistributableEntity
   {
      protected DistributableCrudServiceBase(IDistributableRepository<TEntity> repository) : base(repository)
      {
      }

      public TEntity GetByDistributedId(IDistributableId distributableId)
      {
         return this.Repository.GetByDistributedId(distributableId);
      }
   }
}
