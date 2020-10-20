using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skyrmium.Composed.Entities
{
    public class Product : IngredientBase
    {
        public readonly INotifier _notifier;
        public Product(INotifier notifier)
        {
            _notifier = notifier;
        }
        public ICollection<IngredientQuantity> Ingredients { get; set; }
        protected override double CalculateFractionCost(double factorQuantity)
        {
            if (this.Ingredients == null || this.Ingredients.Count == 0)
            {
                _notifier.Notify("Product", "Un Producto debe contener al menos un ingrediente!", Severity.Error);
                return 0d;
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
