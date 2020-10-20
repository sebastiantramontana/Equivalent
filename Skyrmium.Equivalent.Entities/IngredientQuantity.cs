using System;

namespace Skyrmium.Composed.Entities
{
    public class IngredientQuantity : EntityBase
    {
        public IIngredient Ingredient { get; set; }
        public Measure Measure { get; set; }
        public double Quantity { get; set; }

        public double CalculateCost()
        {
            return this.Ingredient.CalculatePartialCost(this.Measure, this.Quantity);
        }
    }
}
