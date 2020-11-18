using Microsoft.EntityFrameworkCore;
using Skyrmium.Dal.Contracts;

namespace Skyrmium.Dal.Implementations
{
   public class UnitOfWork : IUnitOfWork
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

      public void Finish()
      {
         if (!_isCanceled)
            _dbContext.SaveChanges();

         _isCanceled = false;
      }
   }
}
