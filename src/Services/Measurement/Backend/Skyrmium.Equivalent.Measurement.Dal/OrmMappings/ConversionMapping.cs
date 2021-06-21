using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skyrmium.Dal.Implementations.OrmMapping;
using Skyrmium.Equivalent.Measurement.Dal.Daos;

namespace Skyrmium.Equivalent.Measurement.Dal.OrmMappings
{
   internal class ConversionMapping : OwnedMappingBase<ConversionDao>
   {
      public ConversionMapping() : base("Conversions")
      {
      }

      protected override void ContinueOwned(EntityTypeBuilder<ConversionDao> builder)
      {
         builder.Property(c => c.Name).IsRequired();
         builder.Navigation(c => c.Equivalences).AutoInclude();
         builder.HasMany(c => c.Equivalences).WithOne(e => e.Conversion).OnDelete(DeleteBehavior.Cascade);
      }
   }
}
