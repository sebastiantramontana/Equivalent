using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Contracts.Queryables;
using System;

namespace Skyrmium.Domain.Contracts.Repositories
{
   public interface IOwnedRepository<TEntity> : IRepository<TEntity> where TEntity : class, IOwnedEntity
   {
      IQueryableEntity<TEntity> GetByOwned(Guid ownedBy);
   }
}
