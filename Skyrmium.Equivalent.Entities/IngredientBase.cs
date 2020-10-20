using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Skyrmium.Composed.Entities
{
    public abstract class IngredientBase : DistributableEntityBase, IIngredient
    {
        public string Name { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public double PackingQuantity { get; set; }
        public Measure PackingMeasure { get; set; }
        public double CalculatePartialCost(Measure measure, double quantity)
        {
            var factorQuantity = 0d;

            if (measure == this.PackingMeasure)
            {
                factorQuantity = quantity / this.PackingQuantity;
            }
            else
            {
                var factor = this.PackingMeasure.GetEquivalence(measure, this); //TODO: ver diseño
                factorQuantity = factor * quantity;
            }

            return CalculateFractionCost(factorQuantity);
        }

        protected abstract double CalculateFractionCost(double factorQuantity);

        public override string ToString()
        {
            return this.Name;
        }
    }
}
