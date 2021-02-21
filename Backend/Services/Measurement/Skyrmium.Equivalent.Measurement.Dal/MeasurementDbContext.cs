using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Skyrmium.Equivalent.Measurement.Dal.Mappings;
using Skyrmium.Infrastructure.Contracts;

namespace Skyrmium.Equivalent.Measurement.Dal
{
   internal class MeasurementDbContext : DbContext
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
   }
}
