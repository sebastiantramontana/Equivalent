using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Services.Contracts;
using Skyrmium.Domain.Services.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skyrmium.Domain.Services.Implementations
{
   public abstract class OwnedCrudServiceBase<TRepository, TEntity> : CrudServiceBase<TRepository, TEntity>, IOwnedCrudService<TEntity>
      where TRepository : IOwnedRepository<TEntity>
      where TEntity : class, IOwnedEntity
   {
      protected OwnedCrudServiceBase(TRepository repository) : base(repository)
      {
      }

      public Task<IEnumerable<TEntity>> GetByOwned(Guid ownedBy)
      {
         return this.Repository.GetByOwned(ownedBy);
      }
   }
}
