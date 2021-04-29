using Microsoft.EntityFrameworkCore;
using Skyrmium.Adapters.Contracts;
using Skyrmium.Dal.Implementations.Repositories;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Skyrmium.Equivalent.Measurement.Dal.Repositories
{
   internal class ConversionRepository : OwnedRepository<Conversion, ConversionDao>, IConversionRepository
   {
      public ConversionRepository(DbContext dbContext, IAdapter<Conversion, ConversionDao> adapter) : base(dbContext, adapter)
      {
      }

      public Task<Conversion> Search(Guid measureEquivalenceFrom, Guid measureEquivalenceTo)
      {
         //TODO
         throw new NotImplementedException();
      }
   }
}
