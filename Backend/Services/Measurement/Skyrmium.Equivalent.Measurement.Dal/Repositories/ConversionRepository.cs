﻿using Microsoft.EntityFrameworkCore;
using Skyrmium.Dal.Implementations.Repositories;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts.Repositories;
using Skyrmium.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skyrmium.Equivalent.Measurement.Dal.Repositories
{
   internal class ConversionRepository : OwnedRepositoryBase<Conversion, ConversionDao>, IConversionRepository
   {
      public ConversionRepository(DbContext dbContext, IMapper<Conversion, ConversionDao> mapper) : base(dbContext, mapper)
      {
      }

      public Task<Conversion> Search(Guid measureEquivalenceFrom, Guid measureEquivalenceTo)
      {
         //TODO
         throw new NotImplementedException();
      }

      protected override Task<ConversionDao> ContinueAdd(ConversionDao dao)
      {
         this.DbContext.Add(dao);
         return Task.FromResult(dao);
      }

      protected override Task<IEnumerable<ConversionDao>> ContinueAdd(IEnumerable<ConversionDao> daos)
      {
         this.DbContext.AddRange(daos);
         return Task.FromResult(daos);
      }

      protected override Task ContinueUpdate(ConversionDao dao)
      {
         this.DbContext.Update(dao);
         return Task.CompletedTask;
      }

      protected override Task ContinueUpdate(IEnumerable<ConversionDao> daos)
      {
         this.DbContext.Set<ConversionDao>().UpdateRange(daos);
         return Task.CompletedTask;
      }

      protected override Task ContinueRemove(Guid id)
      {
         this.DbContext.Remove(new ConversionDao { Id = id });
         return Task.CompletedTask;
      }

      protected override Task ContinueRemove(IEnumerable<Guid> ids)
      {
         this.DbContext
            .Set<ConversionDao>()
            .RemoveRange(ids.Select(id => new ConversionDao { Id = id }));

         return Task.CompletedTask;
      }
   }
}
