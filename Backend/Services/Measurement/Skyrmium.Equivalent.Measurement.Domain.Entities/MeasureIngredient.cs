using System;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities
{
   public class MeasureIngredient : IEquatable<MeasureIngredient>
   {
      public MeasureIngredient(Measure measure, Guid ingredient)
      {
         this.Measure = measure;
         this.Ingredient = ingredient;
      }

      public Measure Measure { get; }
      public Guid Ingredient { get; }

      public bool Equals(MeasureIngredient? other)
      {
         return other is not null
            && other.Ingredient == this.Ingredient
            && other.Measure == this.Measure;
      }

      public override bool Equals(object? obj)
      {
         return Equals(obj as MeasureIngredient);
      }

      public override int GetHashCode()
      {
         return (this.Measure, this.Ingredient).GetHashCode();
      }

      public static bool operator ==(MeasureIngredient? e1, MeasureIngredient? e2)
      {
         return e1?.Equals(e2) ?? false;
      }

      public static bool operator !=(MeasureIngredient? e1, MeasureIngredient? e2)
      {
         return !(e1 == e2);
      }
   }
}
