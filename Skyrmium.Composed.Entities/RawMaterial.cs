using System;

namespace Skyrmium.Composed.Entities
{
    public class RawMaterial : IngredientBase
    {
        public Generic Generic { get; set; }
        public Brand Brand { get; set; }
        public double PackingCost { get; set; }
        protected override double CalculateFractionCost(double factorQuantity)
        {
            return this.PackingCost * factorQuantity;
        }
    }
}
