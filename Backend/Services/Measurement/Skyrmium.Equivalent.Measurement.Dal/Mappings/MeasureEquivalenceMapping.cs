using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skyrmium.Dal.Implementations;
using Skyrmium.Equivalent.Measurement.Dal.Daos;

namespace Skyrmium.Equivalent.Measurement.Dal.Mappings
{
   internal class MeasureEquivalenceMapping : MappingBase<MeasureEquivalenceDao>
   {
      public MeasureEquivalenceMapping() : base("MeasureEquivalences")
      {
      }

      protected override void Continue(EntityTypeBuilder<MeasureEquivalenceDao> builder)
      {
         builder.Property(e => e.Factor).IsRequired();
         builder.Property(e => e.MeasureFrom).IsRequired();
         builder.Property(e => e.MeasureTo).IsRequired();
         builder.Property(e => e.IngredientFrom);
         builder.Property(e => e.IngredientTo);
         builder.Property(e => e.OwnedBy);
      }
   }
}
