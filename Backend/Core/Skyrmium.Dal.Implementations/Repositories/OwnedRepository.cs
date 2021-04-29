using Microsoft.EntityFrameworkCore;
using Skyrmium.Adapters.Contracts;
using Skyrmium.Dal.Contracts.Daos;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skyrmium.Dal.Implementations.Repositories
{
   public class OwnedRepository<TEntity, TDao> : Repository<TEntity, TDao>, IOwnedRepository<TEntity>
      where TEntity : class, IOwnedEntity
      where TDao : class, IOwnedDao
   {
      public OwnedRepository(DbContext dbContext, IAdapter<TEntity, TDao> adapter)
         : base(dbContext, adapter)
      {
      }

      public async Task<IEnumerable<TEntity>> GetByOwned(Guid ownedBy)
      {
         var daos = await this.DbContext
            .Set<TDao>()
            .Where(dao => dao.OwnedBy == ownedBy)
            .ToListAsync();

         return this.Adapter.Map(daos);
      }
   }
}