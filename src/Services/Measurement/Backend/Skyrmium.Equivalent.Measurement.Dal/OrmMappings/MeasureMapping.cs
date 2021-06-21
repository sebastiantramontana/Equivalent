using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skyrmium.Dal.Implementations.OrmMapping;
using Skyrmium.Equivalent.Measurement.Dal.Daos;

namespace Skyrmium.Equivalent.Measurement.Dal.OrmMappings
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
