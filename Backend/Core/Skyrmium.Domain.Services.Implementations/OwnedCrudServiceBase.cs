﻿using Skyrmium.Dal.Contracts.Repositories;
using Skyrmium.Domain.Contracts;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Services.Contracts;
using System.Collections.Generic;

namespace Skyrmium.Domain.Services.Implementations
{
   public abstract class OwnedCrudServiceBase<TEntity> : CrudServiceBase<IOwnedRepository<TEntity>, TEntity>, IOwnedCrudService<TEntity>
      where TEntity : IOwnedEntity
   {
      protected OwnedCrudServiceBase(IOwnedRepository<TEntity> repository) : base(repository)
      {
      }

      public IEnumerable<TEntity> GetByOwned(IDistributableId ownedBy)
      {
         return this.Repository.GetByOwned(ownedBy).ToEnumerable();
      }
   }
}
