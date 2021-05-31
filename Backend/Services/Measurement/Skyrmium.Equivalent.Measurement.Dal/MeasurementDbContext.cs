using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Skyrmium.Dal.Contracts;
using Skyrmium.Equivalent.Measurement.Dal.OrmMappings;
using Skyrmium.Infrastructure.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skyrmium.Equivalent.Measurement.Dal
{
   internal class MeasurementDbContext : DbContext, IDataAccess
   {
      private readonly string _connectionString;

      public MeasurementDbContext(IConfiguration configuration)
      {
         _connectionString = configuration.ConnectionString;

         this.ChangeTracker.LazyLoadingEnabled = true;
         this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
         this.ChangeTracker.AutoDetectChangesEnabled = false;
         this.ChangeTracker.CascadeDeleteTiming = CascadeTiming.Never;
         this.ChangeTracker.DeleteOrphansTiming = CascadeTiming.Never;
      }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         optionsBuilder.UseSqlServer(_connectionString);

         base.OnConfiguring(optionsBuilder);
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.ApplyConfiguration(new MeasureMapping());
         modelBuilder.ApplyConfiguration(new MeasureEquivalenceMapping());
         modelBuilder.ApplyConfiguration(new ConversionMapping());
         modelBuilder.ApplyConfiguration(new OrderedMeasureEquivalenceMapping());

         base.OnModelCreating(modelBuilder);
      }

      Task<TDao> IDataAccess.Create<TDao>(TDao dao)
      {
         Add(dao);
         return Task.FromResult(dao);
      }

      Task<IEnumerable<TDao>> IDataAccess.Create<TDao>(IEnumerable<TDao> daos)
      {
         Set<TDao>().AddRange(daos);
         return Task.FromResult(daos);
      }

      Task IDataAccess.Delete<TDao>(TDao dao)
      {
         Remove(dao);
         return Task.CompletedTask;
      }

      Task IDataAccess.Delete<TDao>(IEnumerable<TDao> daos)
      {
         Set<TDao>().RemoveRange(daos);
         return Task.CompletedTask;
      }

      IQueryable<TDao> IDataAccess.Query<TDao>()
      {
         return Set<TDao>();
      }

      Task IDataAccess.Update<TDao>(TDao dao)
      {
         base.Update(dao);
         return Task.CompletedTask;
      }

      Task IDataAccess.Update<TDao>(IEnumerable<TDao> daos)
      {
         base.Update(daos);
         return Task.CompletedTask;
      }
   }
}
