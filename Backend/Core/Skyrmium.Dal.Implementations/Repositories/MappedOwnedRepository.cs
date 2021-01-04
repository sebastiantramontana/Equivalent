using Microsoft.EntityFrameworkCore;
using Skyrmium.Adapters.Contracts;
using Skyrmium.Dal.Contracts.Daos;
using Skyrmium.Domain.Contracts;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Contracts.Queryables;
using Skyrmium.Domain.Contracts.Repositories;

namespace Skyrmium.Dal.Implementations.Repositories
{
   public class MappedOwnedRepository<TEntity, TDao> : MappedRepository<TEntity, TDao>, IOwnedRepository<TEntity>
      where TEntity : IOwnedEntity
      where TDao : class, IOwnedDao
   {
      public MappedOwnedRepository(DbContext dbContext, IQueryableEntity<TEntity> queryableEntity, IExpressionAdapter<TEntity, TDao> dalAdapter)
         : base(dbContext, queryableEntity, dalAdapter)
      {
      }

      public IQueryableEntity<TEntity> GetByOwned(IDistributableId ownedBy)
      {
         var daos = this.QueryableEntity
           .Where(dao => dao.OwnedBy == ownedBy);

         return daos;
      }
   }
}