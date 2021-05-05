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
         builder.Property(e => e.Name).IsRequired();
         builder.Navigation(e => e.Equivalences).AutoInclude();
      }
   }
}
