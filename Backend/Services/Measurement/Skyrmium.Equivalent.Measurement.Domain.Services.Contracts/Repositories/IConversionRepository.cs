using Skyrmium.Domain.Contracts.Repositories;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Skyrmium.Equivalent.Measurement.Domain.Services.Contracts.Repositories
{
   public interface IConversionRepository : IOwnedRepository<Conversion>
   {
      //TODO
      Task<Conversion> Search(Guid measureEquivalenceFrom, Guid measureEquivalenceTo);
   }
}
