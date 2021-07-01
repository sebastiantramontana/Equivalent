﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skyrmium.Dal.Implementations.OrmMapping;
using Skyrmium.Equivalent.Measurement.Dal.Daos;

namespace Skyrmium.Equivalent.Measurement.Dal.OrmMappings
{
   internal class OrderedMeasureEquivalenceMapping : MappingBase<OrderedMeasureEquivalenceDao>
   {
      internal OrderedMeasureEquivalenceMapping() : base("OrderedMeasureEquivalences")
      {
      }

      protected override void Continue(EntityTypeBuilder<OrderedMeasureEquivalenceDao> builder)
      {
         builder.Property(o => o.Order).IsRequired();
         builder.Navigation(o => o.MeasureEquivalence).AutoInclude().IsRequired();
         builder.Property(o => o.InvertEquivalence).IsRequired();
      }
   }
}