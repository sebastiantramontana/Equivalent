using Microsoft.EntityFrameworkCore;
using Skyrmium.Dal.Contracts.Daos;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Services.Contracts.Repositories;
using Skyrmium.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skyrmium.Dal.Implementations.Repositories
{
   public class OwnedRepository<TEntity, TDao> : Repository<TEntity, TDao>, IOwnedRepository<TEntity>
      where TEntity : class, IOwnedEntity
      where TDao : class, IOwnedDao, new()
   {
      public OwnedRepository(DbContext dbContext, IMapper<TEntity, TDao> mapper)
         : base(dbContext, mapper)
      {
      }

      public async Task<IEnumerable<TEntity>> GetByOwned(Guid ownedBy)
      {
         var daos = await this.DbContext
            .Set<TDao>()
            .Where(dao => dao.OwnedBy == ownedBy)
            .ToListAsync();

         return this.Mapper.Map(daos);
      }
   }
}