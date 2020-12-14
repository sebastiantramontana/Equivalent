using Microsoft.EntityFrameworkCore;
using Skyrmium.Dal.Contracts;
using Skyrmium.Dal.Contracts.Adapters;
using Skyrmium.Dal.Contracts.Daos;
using Skyrmium.Domain.Contracts;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Contracts.Queryables;
using Skyrmium.Domain.Contracts.Repositories;

namespace Skyrmium.Dal.Implementations.Repositories
{
   public class MappedDistributableRepository<TEntity, TDao> : MappedRepository<TEntity, TDao>, IDistributableRepository<TEntity>
      where TEntity : IDistributableEntity
      where TDao : class, IDistributableDao
   {
      public MappedDistributableRepository(DbContext dbContext, IQueryableEntity<TEntity> queryableEntity, IDalAdapter<TEntity, TDao> dalAdapter)
         : base(dbContext, queryableEntity, dalAdapter)
      {
      }

      public TEntity GetByDistributedId(IDistributableId distributedId)
      {
         var dao = this.QueryableEntity
           .SingleOrDefault(dao => dao.DistributedId == distributedId)
           ?? throw new ObjectNotFoundException();

         return dao;
      }
   }
}