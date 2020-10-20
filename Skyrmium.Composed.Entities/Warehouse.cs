using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skyrmium.Composed.Entities
{
    public class Warehouse : DistributableEntityBase
    {
        public readonly INotifier _notifier;
        public Warehouse(INotifier notifier)
        {
            _notifier = notifier;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<IngredientStock> CurrentStock { get; set; }
        public void AddToStock(IIngredient ingredient, Measure measure, double quantity)
        {
            double factor = measure.GetEquivalence(ingredient.PackingMeasure, ingredient);
            quantity *= factor;

            var ingStock = this.CurrentStock.SingleOrDefault(c => c.Ingredient == ingredient);

            if (ingStock == null)
            {
                ingStock = new IngredientStock
                {
                    Ingredient = ingredient,
                    Quantity = quantity
                };

                this.CurrentStock.Add(ingStock);
            }
            else
            {
                ingStock.Quantity += quantity;
            }

            if (ingStock.Quantity < 0)
            {
                _notifier.Notify("Stock", "La cantidad de un ingrediente en stock NO puede ser menor a cero!", Severity.Warning);
            }
        }
    }
}
