using Skyrmium.Domain.Contracts;
using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Implementations.Entities;
using Skyrmium.Domain.Implementations.Exceptions;
using Skyrmium.Equivalent.Measurement.Domain.Entities.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities
{
   public class Conversion : OwnedEntityBase, IOwnedEntity
   {
      public static Conversion Create(long id, IDistributableId distributedId, IDistributableId ownedBy, string name, IEnumerable<MeasureEquivalence> equivalences)
      {
         if (!Validate(equivalences))
         {
            var exceptionValues = new Dictionary<InvalidConversionExceptionValues, object>(1)
            {
               { InvalidConversionExceptionValues.Name, name }
            };

            throw BusinessExceptionFactory
               .Create(MeasurementEntityExceptions.InvalidConversion, "Conversion", exceptionValues)
               .ToException();
         }

         return new Conversion(id, distributedId, ownedBy, name, equivalences);
      }

      private Conversion(long id, IDistributableId distributedId, IDistributableId ownedBy, string name, IEnumerable<MeasureEquivalence> equivalences) : base(id, distributedId, ownedBy)
      {
         this.Name = name;
         this.Equivalences = equivalences;
      }

      public string Name { get; }
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
