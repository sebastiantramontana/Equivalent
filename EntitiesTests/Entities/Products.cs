using Skyrmium.Equivalent.DomainModel.Entities;
using System.Collections.Generic;

namespace EntitiesTests.Entities
{
   public static class Products
   {
      public static Product Salad
      {
         get => GetInstance("Salad", Measures.Unit.Instance, 1.0, new[] {
                IngredientQuantity(RawMaterials.Tomato.Instance, Measures.Gr.Instance,200.0),
                IngredientQuantity(RawMaterials.Lettuce.Instance, Measures.Gr.Instance,100.0),
                IngredientQuantity(RawMaterials.Oil.Instance, Measures.Dash.Instance,100.0),
                IngredientQuantity(RawMaterials.Salt.Instance, Measures.Pinch.Instance,3.0)
        });
      }

      private static IngredientQuantity IngredientQuantity(IIngredient ingredient, Measure measure, double quantity)
      {
         return new IngredientQuantity { Ingredient = ingredient, Measure = measure, Quantity = quantity };
      }
      public static Product GetInstance(string name, Measure packingMeasure, double packingQuantity, ICollection<IngredientQuantity> ingredients)
      {
         return new Product()
         {
            Name = name,
            PackingMeasure = packingMeasure,
            PackingQuantity = packingQuantity,
            Ingredients = ingredients
         };
      }
   }
}
