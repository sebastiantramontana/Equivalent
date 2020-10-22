using Skyrmium.DomainModel.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skyrmium.Equivalent.DomainModel.Entities
{
   public class Branch : DistributableEntityBase
   {
      public string Name { get; set; }
      public string Description { get; set; }
      public Warehouse Warehouse { get; set; }
      public ICollection<Movement> Movements { get; set; }

      public void AddIngredientToStock(IIngredient ingredient, Measure measure, double quantity, MovementReason reason)
      {
         RegisterMovement(ingredient, measure, quantity, reason, null);
         this.Warehouse.AddToStock(ingredient, measure, quantity);
      }

      public void AddIngredientToStock(IIngredient ingredient, Measure measure, double quantity, string anotherReasonDescription)
      {
         RegisterMovement(ingredient, measure, quantity, MovementReason.Another, anotherReasonDescription);
         this.Warehouse.AddToStock(ingredient, measure, quantity);
      }

      public void SubstractIngredientFromStock(IIngredient ingredient, Measure measure, double quantity, MovementReason reason)
      {
         RegisterMovement(ingredient, measure, -quantity, reason, null);
         this.Warehouse.AddToStock(ingredient, measure, -quantity);
      }

      public void SubstractIngredientFromStock(IIngredient ingredient, Measure measure, double quantity, string anotherReasonDescription)
      {
         RegisterMovement(ingredient, measure, -quantity, MovementReason.Another, anotherReasonDescription);
         this.Warehouse.AddToStock(ingredient, measure, -quantity);
      }

      public IEnumerable<Movement> GetMovements(int daysToBack)
      {
         return Movements.Where(m => m.DateTime.Date >= DateTime.Today.Subtract(TimeSpan.FromDays(daysToBack)));
      }

      public IEnumerable<Movement> GetMovements(DateTime from, DateTime to)
      {
         return Movements.Where(m => m.DateTime.Date >= from && m.DateTime.Date <= to);
      }

      private void RegisterMovement(IIngredient ingredient, Measure measure, double quantity, MovementReason reason, string anotherReasonDescription)
      {
         if (reason == MovementReason.Another && string.IsNullOrWhiteSpace(anotherReasonDescription))
         {
            throw new BusinessException("Movement", "'anotherReasonDescription' NO debe estar en blanco si 'reason' es Another");
         }

         Movements.Add(new Movement { DateTime = DateTime.Now, Ingredient = ingredient, Measure = measure, Quantity = quantity, Reason = reason, AnotherReasonDescription = anotherReasonDescription });
      }
   }
}
