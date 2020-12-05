using Microsoft.EntityFrameworkCore;
using Skyrmium.Dal.Contracts.Adapters;
using Skyrmium.Dal.Contracts.Daos;
using Skyrmium.Dal.Contracts.Queryables;
using Skyrmium.Dal.Contracts.Repositories;
using Skyrmium.Domain.Contracts;
using Skyrmium.Domain.Contracts.Entities;

namespace Skyrmium.Dal.Implementations.Repositories
{
   public class MappedOwnedDistributableRepository<TEntity, TDao> : MappedRepository<TEntity, TDao>, IOwnedDistributableRepository<TEntity>
      where TEntity : IOwnedDistributableEntity
      where TDao : class, IOwnedDistributableDao
   {
      private readonly IOwnedRepository<TEntity> _ownedRepository;
      private readonly IDistributableRepository<TEntity> _distributableRepository;

      public MappedOwnedDistributableRepository(DbContext dbContext, IQueryableEntity<TEntity> queryableEntity, IDalAdapter<TEntity, TDao> dalAdapter, IOwnedRepository<TEntity> ownedRepository, IDistributableRepository<TEntity> distributableRepository)
         : base(dbContext, queryableEntity, dalAdapter)
      {
         _ownedRepository = ownedRepository;
         _distributableRepository = distributableRepository;
      }

      public TEntity GetByDistributedId(IDistributableId distributedId)
      {
         return _distributableRepository.GetByDistributedId(distributedId);
      }

      public IQueryableEntity<TEntity> GetByOwned(IDistributableId ownedBy)
      {
         return _ownedRepository.GetByOwned(ownedBy);
      }
   }
}
