using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
         builder.Property(e => e.Name).IsRequired();
         builder.Navigation(e => e.Equivalences).AutoInclude();
      }
   }
}
