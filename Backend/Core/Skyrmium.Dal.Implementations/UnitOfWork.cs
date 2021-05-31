using Microsoft.EntityFrameworkCore;
using Skyrmium.Dal.Contracts;
using System;
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

      public Task Finish()
      {
         if (!_isCanceled)
            _dbContext.SaveChanges();

         _isCanceled = true;
         return _dbContext.DisposeAsync().AsTask();
      }
   }
}
