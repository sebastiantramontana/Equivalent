using Skyrmium.DomainModel.Entities.Contracts;

namespace Skyrmium.Equivalent.DomainModel.Entities
{
   public class IngredientStock : EntityBase
   {
      public IIngredient Ingredient { get; set; }
      /// <summary>
      /// El Quantity siempre es medido de acuerdo a Ingredient.PackingMeasure. Si se modifica Ingredient.PackingMeasure, se deben modificar los quantities de todos los stocks para ese Ingredient
      /// </summary>
      public double Quantity { get; set; }
   }
}
