using Skyrmium.DomainModel.Entities.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Skyrmium.Equivalent.DomainModel.Entities
{
   public class Measure : DistributableEntityBase
   {
      public string Name { get; set; }
      public string Symbol { get; set; }
      public bool IsPrecise { get; set; }
      public ICollection<MeasureEquivalence> Equivalences { get; set; }
      public double GetEquivalence(Measure measureTo)
      {
         return GetEquivalence(measureTo, null);
      }
      public double GetEquivalence(Measure measureTo, IIngredient ingredient)
      {
         double factor;

         if (this.Equals(measureTo))
         {
            factor = 1.0;
         }
         else
         {
            var equiv = Equivalences.SingleOrDefault(e => e.From == this && e.To == measureTo && e.Ingredient == ingredient);

            if (equiv == null)
            {
               //pruebo la equivalencia opuesta
               equiv = Equivalences.SingleOrDefault(e => e.From == measureTo && e.To == this && e.Ingredient == ingredient);

               if (equiv == null)
               {
                  throw new BusinessException("Equivalence", $"Equivalencia inexistente entre {this.Name} y {measureTo.Name}!");
               }

               factor = 1.0 / equiv.Factor; //invierto la equivalencia
            }
            else
            {
               factor = equiv.Factor;
            }
         }

         return factor;
      }
      public override string ToString()
      {
         return this.Name;
      }
   }
}
