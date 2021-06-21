using Skyrmium.Domain.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skyrmium.Domain.Services.Contracts.Repositories
{
   public interface IOwnedRepository<TEntity> : IRepository<TEntity> where TEntity : class, IOwnedEntity
   {
      Task<IEnumerable<TEntity>> GetByOwned(Guid ownedBy);
   }
}
