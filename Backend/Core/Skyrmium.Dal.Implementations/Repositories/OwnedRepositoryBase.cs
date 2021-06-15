using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Skyrmium.Dal.Contracts;
using Skyrmium.Dal.Contracts.Daos;
using Skyrmium.Dal.Contracts.Localization;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Services.Contracts.Repositories;
using Skyrmium.Infrastructure.Contracts;

namespace Skyrmium.Dal.Implementations.Repositories
{
   public abstract class OwnedRepositoryBase<TEntity, TDao> : RepositoryBase<TEntity, TDao>, IOwnedRepository<TEntity>
      where TEntity : class, IOwnedEntity
      where TDao : class, IOwnedDao, new()
   {
      public OwnedRepositoryBase(IDataAccess dataAccess, IMapper<TEntity, TDao> mapper, IRepositoryLocalizer localizer)
         : base(dataAccess, mapper, localizer)
      {
      }

      public async Task<IEnumerable<TEntity>> GetByOwned(Guid ownedBy)
      {
         var daos = await this.DataAccess
            .Query<TDao>()
            .Where(dao => dao.OwnedBy == ownedBy)
            .ToListAsync();

         return this.Mapper.Map(daos);
      }
   }
}