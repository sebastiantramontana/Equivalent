using Skyrmium.DomainModel.Entities.Contracts;
using System.Collections.Generic;

namespace Skyrmium.Equivalent.DomainModel.Entities
{
   public class Product : IngredientBase
   {
      public ICollection<IngredientQuantity> Ingredients { get; set; }

      protected override double CalculateFractionCost(double factorQuantity)
      {
         if (this.Ingredients == null || this.Ingredients.Count == 0)
         {
            throw new BusinessException("Product", "Un Producto debe contener al menos un ingrediente!");
         }

         var total = 0d;

         foreach (var ing in this.Ingredients)
         {
            total += ing.CalculateCost();
         }

         return total * factorQuantity;
      }
   }
}
