using Skyrmium.Domain.Contracts;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Implementations.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities
{
   public class Conversion : OwnedEntityBase, IOwnedEntity
   {
      public static Conversion Create(long id, IDistributableId distributedId, IDistributableId ownedBy, IEnumerable<MeasureEquivalence> equivalences)
      {
         if (!Validate(equivalences))
            throw new Exception(); //TODO: Usar factory 

         return new Conversion(id, distributedId, ownedBy, equivalences);
      }

      private Conversion(long id, IDistributableId distributedId, IDistributableId ownedBy, IEnumerable<MeasureEquivalence> equivalences) : base(id, distributedId, ownedBy)
      {

         this.Equivalences = equivalences;
      }

      public IEnumerable<MeasureEquivalence> Equivalences { get; }

      private static bool Validate(IEnumerable<MeasureEquivalence> equivalences)
      {
         if (!equivalences.Any())
            return false;

         MeasureIngredient prevTo = equivalences.First().From;

         foreach (var equivalence in equivalences)
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
