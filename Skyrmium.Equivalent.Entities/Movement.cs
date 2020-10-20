using System;
using System.Collections.Generic;
using System.Text;

namespace Skyrmium.Composed.Entities
{
    public class Movement : EntityBase
    {
        public DateTime DateTime { get; set; }
        public IIngredient Ingredient { get; set; }
        public Measure Measure { get; set; }
        public double Quantity { get; set; }
        public MovementReason Reason { get; set; }
        public string AnotherReasonDescription { get; set; }
    }
}
