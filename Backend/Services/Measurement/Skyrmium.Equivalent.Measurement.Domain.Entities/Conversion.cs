using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Implementations.Entities;
using Skyrmium.Domain.Implementations.Exceptions;
using Skyrmium.Equivalent.Measurement.Domain.Entities.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities
{
   public class Conversion : OwnedEntityBase
   {
      public static Conversion Create(long id, IDistributableId distributedId, IDistributableId ownedBy, string name, IEnumerable<OrderedMeasureEquivalence> equivalences)
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

      private Conversion(long id, IDistributableId distributedId, IDistributableId ownedBy, string name, IEnumerable<OrderedMeasureEquivalence> equivalences) : base(id, distributedId, ownedBy)
      {
         this.Name = name;
         this.Equivalences = equivalences;
      }

      public string Name { get; }
      public IEnumerable<OrderedMeasureEquivalence> Equivalences { get; }

      private static bool Validate(IEnumerable<OrderedMeasureEquivalence> equivalences)
      {
         if (!CheckIsNotEmpty(equivalences))
            return false;

         if (!CheckOrderIsUnique(equivalences))
            return false;

         var orderedEquivalences = equivalences.OrderBy(e => e.Order);

         var prevTo = GetFirstEquivalenceTo(orderedEquivalences);
         var fromSecondOrderedEquivalences = StartFromSecondEquivalence(orderedEquivalences);

         foreach (var equivalence in fromSecondOrderedEquivalences)
         {
            if (!CheckPreviousToWithNextFrom(prevTo, equivalence.From))
               return false;

            prevTo = equivalence.To;
         }

         return true;
      }

      private static IEnumerable<MeasureEquivalence> StartFromSecondEquivalence(IEnumerable<OrderedMeasureEquivalence> orderedEquivalences)
      {
         return orderedEquivalences
                  .Skip(1)
                  .Select(oe => oe.MeasureEquivalence);
      }

      private static MeasureIngredient GetFirstEquivalenceTo(IEnumerable<OrderedMeasureEquivalence> orderedEquivalences)
      {
         return orderedEquivalences
                  .First()
                  .MeasureEquivalence
                  .To;
      }

      private static bool CheckPreviousToWithNextFrom(MeasureIngredient prevTo, MeasureIngredient nextFrom)
      {
         return prevTo == nextFrom || (prevTo.Measure == nextFrom.Measure && nextFrom.Ingredient.IsNone);
      }

      private static bool CheckIsNotEmpty(IEnumerable<OrderedMeasureEquivalence> equivalences)
      {
         return equivalences.Any();
      }

      private static bool CheckOrderIsUnique(IEnumerable<OrderedMeasureEquivalence> equivalences)
      {
         return equivalences.GroupBy(e => e.Order).All(g => g.Count() == 1);
      }
   }
}
