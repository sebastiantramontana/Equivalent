using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skyrmium.Dal.Implementations.Mapping;
using Skyrmium.Equivalent.Measurement.Dal.Daos;

namespace Skyrmium.Equivalent.Measurement.Dal.Mappings
{
   internal class ConversionMapping : OwnedMappingBase<ConversionDao>
   {
      public ConversionMapping() : base("Conversions")
      {
      }

      protected override void ContinueOwned(EntityTypeBuilder<ConversionDao> builder)
      {
         builder.HasMany(c => c.Equivalences);
      }
   }
}
