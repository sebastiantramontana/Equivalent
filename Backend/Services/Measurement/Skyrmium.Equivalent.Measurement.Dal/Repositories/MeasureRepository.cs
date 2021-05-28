using Microsoft.EntityFrameworkCore;
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
   internal class MeasureRepository : OwnedRepositoryBase<Measure, MeasureDao>, IMeasureRepository
   {
      public MeasureRepository(DbContext dbContext, IMapper<Measure, MeasureDao> mapper)
         : base(dbContext, mapper)
      {
      }

      protected override Task<MeasureDao> ContinueAdd(MeasureDao dao)
      {
         this.DbContext.Add(dao);
         return Task.FromResult(dao);
      }

      protected override Task<IEnumerable<MeasureDao>> ContinueAdd(IEnumerable<MeasureDao> daos)
      {
         this.DbContext.AddRange(daos);
         return Task.FromResult(daos);
      }

      protected override Task ContinueUpdate(MeasureDao dao)
      {
         this.DbContext.Update(dao);
         return Task.CompletedTask;
      }

      protected override Task ContinueUpdate(IEnumerable<MeasureDao> daos)
      {
         this.DbContext.UpdateRange(daos);
         return Task.CompletedTask;
      }

      protected override Task ContinueRemove(Guid id)
      {
         this.DbContext.Remove(new MeasureDao { Id = id });
         return Task.CompletedTask;
      }

      protected override Task ContinueRemove(IEnumerable<Guid> ids)
      {
         this.DbContext
            .Set<MeasureDao>()
            .RemoveRange(ids.Select(id => new MeasureDao { Id = id }));

         return Task.CompletedTask;
      }
   }
}
