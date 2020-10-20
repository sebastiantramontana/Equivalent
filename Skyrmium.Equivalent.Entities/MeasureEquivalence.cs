using System;
using System.Collections.Generic;
using System.Text;

namespace Skyrmium.Composed.Entities
{
    public class MeasureEquivalence : EntityBase
    {
        public Measure From { get; set; }
        public Measure To { get; set; }
        public double Factor { get; set; }
        public IIngredient Ingredient { get; set; }
    }
}
