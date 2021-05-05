using Microsoft.EntityFrameworkCore;
using Skyrmium.Dal.Implementations.Repositories;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts.Repositories;
using Skyrmium.Infrastructure.Contracts;
using System;
using System.Threading.Tasks;

namespace Skyrmium.Equivalent.Measurement.Dal.Repositories
{
   internal class ConversionRepository : OwnedRepository<Conversion, ConversionDao>, IConversionRepository
   {
      public ConversionRepository(DbContext dbContext, IMapper<Conversion, ConversionDao> mapper) : base(dbContext, mapper)
      {
      }

      public Task<Conversion> Search(Guid measureEquivalenceFrom, Guid measureEquivalenceTo)
      {
         //TODO
         throw new NotImplementedException();
      }
   }
}
