using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skyrmium.Dal.Implementations.Mapping;
using Skyrmium.Equivalent.Measurement.Dal.Daos;

namespace Skyrmium.Equivalent.Measurement.Dal.Mappings
{
   class OrderedMeasureEquivalenceMapping : MappingBase<OrderedMeasureEquivalenceDao>
   {
      public OrderedMeasureEquivalenceMapping() : base("OrderedMeasureEquivalences")
      {
      }

      protected override void Continue(EntityTypeBuilder<OrderedMeasureEquivalenceDao> builder)
      {
         builder.Property(o => o.Order).IsRequired();
         builder.Navigation(o => o.MeasureEquivalence).AutoInclude().IsRequired();
      }
   }
}
