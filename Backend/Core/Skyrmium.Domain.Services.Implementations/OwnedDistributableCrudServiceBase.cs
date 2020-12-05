using Skyrmium.Dal.Contracts.Repositories;
using Skyrmium.Domain.Contracts;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Services.Contracts;
using System.Collections.Generic;

namespace Skyrmium.Domain.Services.Implementations
{
   public abstract class OwnedDistributableCrudServiceBase<TEntity> : CrudServiceBase<IOwnedDistributableRepository<TEntity>, TEntity>, IOwnedDistributableCrudService<TEntity>
      where TEntity : IOwnedDistributableEntity

   {
      private readonly IDistributableCrudService<TEntity> _distributableCrudService;
      private readonly IOwnedCrudService<TEntity> _ownedCrudService;

      protected OwnedDistributableCrudServiceBase(IOwnedDistributableRepository<TEntity> repository, IDistributableCrudService<TEntity> distributableCrudService, IOwnedCrudService<TEntity> ownedCrudService) : base(repository)
      {
         _distributableCrudService = distributableCrudService;
         _ownedCrudService = ownedCrudService;
      }

      public TEntity GetByDistributedId(IDistributableId distributableId)
      {
         return _distributableCrudService.GetByDistributedId(distributableId);
      }

      public IEnumerable<TEntity> GetByOwned(IDistributableId ownedBy)
      {
         return _ownedCrudService.GetByOwned(ownedBy);
      }
   }
}
