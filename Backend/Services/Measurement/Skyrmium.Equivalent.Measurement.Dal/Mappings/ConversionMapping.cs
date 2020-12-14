using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skyrmium.Dal.Implementations;
using Skyrmium.Equivalent.Measurement.Dal.Daos;

namespace Skyrmium.Equivalent.Measurement.Dal.Mappings
{
   internal class ConversionMapping : MappingBase<ConversionDao>
   {
      public ConversionMapping() : base("Conversions")
      {
      }

      protected override void Continue(EntityTypeBuilder<ConversionDao> builder)
      {
         builder.HasMany(c => c.Equivalences);
         builder.Property(e => e.OwnedBy);
      }
   }
}
