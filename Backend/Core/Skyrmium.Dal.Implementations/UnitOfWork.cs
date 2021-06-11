using Microsoft.EntityFrameworkCore;
using Skyrmium.Dal.Contracts;
using System.Threading.Tasks;

namespace Skyrmium.Dal.Implementations
{
   internal class UnitOfWork : IUnitOfWork
   {
      private readonly DbContext _dbContext;
      private bool _isCanceled = false;

      public UnitOfWork(DbContext dbContext)
      {
         _dbContext = dbContext;
      }

      public void Cancel()
      {
         _isCanceled = true;
      }

      public async Task Finish()
      {
         if (!_isCanceled)
            await _dbContext.SaveChangesAsync();

         _isCanceled = true;
         await _dbContext.DisposeAsync();
      }
   }
}
