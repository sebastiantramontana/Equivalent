using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skyrmium.Dal.Implementations.Mapping;
using Skyrmium.Equivalent.Measurement.Dal.Daos;

namespace Skyrmium.Equivalent.Measurement.Dal.Mappings
{
   internal class MeasureMapping : OwnedMappingBase<MeasureDao>
   {
      public MeasureMapping() : base("Measures")
      {
      }

      protected override void ContinueOwned(EntityTypeBuilder<MeasureDao> builder)
      {
         builder.Property(e => e.FullName).IsRequired();
         builder.Property(e => e.ShortName);
      }
   }
}
