using Microsoft.EntityFrameworkCore;
using Skyrmium.Adapters.Contracts;
using Skyrmium.Dal.Contracts.Daos;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Contracts.Queryables;
using Skyrmium.Domain.Contracts.Repositories;
using System;
using System.Linq;

namespace Skyrmium.Dal.Implementations.Repositories
{
   public class MappedOwnedRepository<TEntity, TDao> : MappedRepository<TEntity, TDao>, IOwnedRepository<TEntity>
      where TEntity : class, IOwnedEntity
      where TDao : class, IOwnedDao
   {
      public MappedOwnedRepository(DbContext dbContext, IQueryableEntity<TEntity> queryableEntity, IAdapter<TEntity, TDao> adapter)
         : base(dbContext, queryableEntity, adapter)
      {
      }

      public IQueryableEntity<TEntity> GetByOwned(Guid ownedBy)
      {
         var entities = this.QueryableEntity
           .Where(entity => entity.OwnedBy == ownedBy);

         return entities;
      }
   }
}