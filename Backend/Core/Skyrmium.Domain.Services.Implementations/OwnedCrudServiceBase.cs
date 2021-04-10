using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Contracts.Repositories;
using Skyrmium.Domain.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skyrmium.Domain.Services.Implementations
{
   public abstract class OwnedCrudServiceBase<TEntity> : CrudServiceBase<IOwnedRepository<TEntity>, TEntity>, IOwnedCrudService<TEntity>
      where TEntity : class, IOwnedEntity
   {
      protected OwnedCrudServiceBase(IOwnedRepository<TEntity> repository) : base(repository)
      {
      }

      public Task<IEnumerable<TEntity>> GetByOwned(Guid ownedBy)
      {
         return this.Repository.GetByOwned(ownedBy).ToEnumerableAsync();
      }
   }
}
