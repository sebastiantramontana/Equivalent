using Skyrmium.Dal.Contracts;
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
      public MeasureRepository(IDataAccess dataAccess, IMapper<Measure, MeasureDao> mapper)
         : base(dataAccess, mapper)
      {
      }

      protected override Task<MeasureDao> ContinueCreate(MeasureDao dao)
      {
         return this.DataAccess.Create(dao);
      }

      protected override Task<IEnumerable<MeasureDao>> ContinueCreate(IEnumerable<MeasureDao> daos)
      {
         return this.DataAccess.Create(daos);
      }

      protected override Task ContinueUpdate(MeasureDao dao)
      {
         return this.DataAccess.Update(dao);
      }

      protected override Task ContinueUpdate(IEnumerable<MeasureDao> daos)
      {
         return this.DataAccess.Update(daos);
      }

      protected override Task ContinueDelete(Guid id)
      {
         return this.DataAccess.Delete(new MeasureDao { Id = id });
      }

      protected override Task ContinueDelete(IEnumerable<Guid> ids)
      {
         return this.DataAccess.Delete(ids.Select(id => new MeasureDao { Id = id }));
      }
   }
}
