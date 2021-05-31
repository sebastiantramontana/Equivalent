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
   internal class ConversionRepository : OwnedRepositoryBase<Conversion, ConversionDao>, IConversionRepository
   {
      public ConversionRepository(IDataAccess dataAccess, IMapper<Conversion, ConversionDao> mapper) : base(dataAccess, mapper)
      {
      }

      public Task<Conversion> Search(Guid measureEquivalenceFrom, Guid measureEquivalenceTo)
      {
         //TODO
         throw new NotImplementedException();
      }

      protected override Task<ConversionDao> ContinueCreate(ConversionDao dao)
      {
         return this.DataAccess.Create(dao);
      }

      protected override Task<IEnumerable<ConversionDao>> ContinueCreate(IEnumerable<ConversionDao> daos)
      {
         return this.DataAccess.Create(daos);
      }

      protected override Task ContinueUpdate(ConversionDao dao)
      {
         return this.DataAccess.Update(dao);
      }

      protected override Task ContinueUpdate(IEnumerable<ConversionDao> daos)
      {
         return this.DataAccess.Update(daos);
      }

      protected override Task ContinueDelete(Guid id)
      {
         var dao = new ConversionDao { Id = id };
         return this.DataAccess.Delete(dao);
      }

      protected override Task ContinueDelete(IEnumerable<Guid> ids)
      {
         var daos = ids.Select(id => new ConversionDao { Id = id });
         return this.DataAccess.Delete(daos);
      }
   }
}
