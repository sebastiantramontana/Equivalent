using Skyrmium.Domain.Contracts;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Implementations.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities
{
   public class Conversion : OwnedEntityBase, IOwnedEntity
   {
      public Conversion(long id, IDistributableId distributedId, IDistributableId ownedBy, IEnumerable<MeasureEquivalence> equivalences) : base(id, distributedId, ownedBy)
      {
         this.Equivalences = equivalences;
      }

      public IEnumerable<MeasureEquivalence> Equivalences { get; }

      public bool Validate()
      {
         if (!this.Equivalences.Any())
            return false;

         MeasureIngredient prevTo = this.Equivalences.First().From;

         foreach (var equivalence in this.Equivalences)
         {
            if (!ValidatePreviousToWithNextFrom(prevTo, equivalence.From))
               return false;

            prevTo = equivalence.To;
         }

         return true;
      }

      private static bool ValidatePreviousToWithNextFrom(MeasureIngredient prevTo, MeasureIngredient nextFrom)
      {
         return prevTo == nextFrom || (prevTo.Measure == nextFrom.Measure && nextFrom.Ingredient.IsNone);
      }
   }
}
