using Skyrmium.DomainModel.Entities.Contracts;
using System;
using System.Collections.Generic;

namespace Skyrmium.Equivalent.DomainModel.Entities
{
   public class StockHistory : EntityBase
   {
      public DateTime DateTime { get; set; }
      public ICollection<IngredientStock> Stock { get; set; }
   }
}
