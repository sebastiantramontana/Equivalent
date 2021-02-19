using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Skyrmium.Equivalent.Measurement.Dal.Mappings;
using Skyrmium.Infrastructure.Contracts;

namespace Skyrmium.Equivalent.Measurement.Dal
{
   internal class MeasurementDbContext : DbContext
   {
      private readonly string _stringConnection;

      internal MeasurementDbContext(IConfiguration configuration)
      {
         _stringConnection = configuration.ConnectionString;

         this.ChangeTracker.LazyLoadingEnabled = true;
         this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
         this.ChangeTracker.AutoDetectChangesEnabled = false;
         this.ChangeTracker.CascadeDeleteTiming = CascadeTiming.Never;
         this.ChangeTracker.DeleteOrphansTiming = CascadeTiming.Never;
      }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         optionsBuilder.UseSqlServer(_stringConnection);

         base.OnConfiguring(optionsBuilder);
      }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.ApplyConfiguration(new MeasureMapping());
         modelBuilder.ApplyConfiguration(new MeasureEquivalenceMapping());
         modelBuilder.ApplyConfiguration(new ConversionMapping());

         base.OnModelCreating(modelBuilder);
      }
   }
}
