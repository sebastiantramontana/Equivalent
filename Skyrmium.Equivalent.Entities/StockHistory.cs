using System;
using System.Collections.Generic;
using System.Text;

namespace Skyrmium.Composed.Entities
{
    public class StockHistory : EntityBase
    {
        public DateTime DateTime { get; set; }
        public ICollection<IngredientStock> Stock { get; set; }
    }
}
