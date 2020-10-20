using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Skyrmium.Composed.Entities
{
    public interface IIngredient : IDistributableEntity
    {
        string Name { get; set; }
        DateTime? ExpirationDate { get; set; }
        double PackingQuantity { get; set; }
        Measure PackingMeasure { get; set; }
        double CalculatePartialCost(Measure measure, double quantity);
    }
}
