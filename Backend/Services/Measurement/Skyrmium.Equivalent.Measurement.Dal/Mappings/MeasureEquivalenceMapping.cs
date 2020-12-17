﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skyrmium.Dal.Implementations.Mapping;
using Skyrmium.Equivalent.Measurement.Dal.Daos;

namespace Skyrmium.Equivalent.Measurement.Dal.Mappings
{
   internal class MeasureEquivalenceMapping : OwnedMappingBase<MeasureEquivalenceDao>
   {
      public MeasureEquivalenceMapping() : base("MeasureEquivalences")
      {
      }

      protected override void ContinueOwned(EntityTypeBuilder<MeasureEquivalenceDao> builder)
      {
         builder.Property(e => e.MeasureFrom).IsRequired();
         builder.Property(e => e.MeasureTo).IsRequired();
         builder.Property(e => e.IngredientFrom);
         builder.Property(e => e.IngredientTo);
         builder.Property(e => e.Factor).IsRequired();
      }
   }
}
