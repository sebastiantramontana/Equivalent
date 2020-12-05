using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skyrmium.Dal.Implementations;
using Skyrmium.Equivalent.Measurement.Dal.Daos;

namespace Skyrmium.Equivalent.Measurement.Dal.Mappings
{
   internal class MeasureMapping : MappingBase<MeasureDao>
   {
      public MeasureMapping() : base("Measures")
      {
      }

      protected override void Continue(EntityTypeBuilder<MeasureDao> builder)
      {
         builder.Property(e => e.DistributedId).IsRequired();
         builder.Property(e => e.FullName).IsRequired();
         builder.Property(e => e.ShortName);
         builder.Property(e => e.OwnedBy);
      }
   }
}
