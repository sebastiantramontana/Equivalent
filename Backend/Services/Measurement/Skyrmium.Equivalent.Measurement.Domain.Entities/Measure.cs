using Skyrmium.Domain.Contracts.Entities;
using Skyrmium.Domain.Implementations.Entities;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities
{
   public class Measure : OwnedEntityBase
   {
      public Measure(long id, IDistributableId distributedId, IDistributableId ownedBy, string fullName, string shortName) : base(id, distributedId, ownedBy)
      {
         this.FullName = fullName;
         this.ShortName = shortName;
      }

      public string FullName { get; } = string.Empty;
      public string ShortName { get; } = string.Empty;

      public override string ToString()
      {
         return ShortName ?? FullName;
      }

      //public double GetEquivalenceFactor(Measure measureTo)
      //{
      //   return GetEquivalenceFactor(measureTo, DistributableId.None);
      //}

      //public double GetEquivalenceFactor(Measure measureTo, IDistributableId ingredientId)
      //{
      //   double factor;

      //   if (Equals(measureTo))
      //   {
      //      factor = 1.0;
      //   }
      //   else
      //   {
      //      factor = GetFitestEquivalenceFactorFromThis(measureTo, ingredientId)
      //               ?? GetFitestEquivalenceFactorToThis(measureTo, ingredientId) //pruebo la equivalencia opuesta
      //               ?? throw BusinessExceptionFactory.CreateInexistentEquivalenceException(this, measureTo);
      //   }

      //   return factor;
      //}

      //private double? GetFitestEquivalenceFactorFromThis(Measure measureTo, IDistributableId ingredientId)
      //{
      //   return GetFitestEquivalenceFactor(e => e.From == this && e.To == measureTo, ingredientId);
      //}

      //private double? GetFitestEquivalenceFactorToThis(Measure measureTo, IDistributableId ingredientId)
      //{
      //   return 1.0 / GetFitestEquivalenceFactor(e => e.From == measureTo && e.To == this, ingredientId);
      //}

      //private double? GetFitestEquivalenceFactor(Func<MeasureEquivalence, bool> measurementConditionFunc, IDistributableId ingredientId)
      //{
      //   var equivs = Equivalences.Where(measurementConditionFunc)
      //      .Where(e => e.IngredientFrom == ingredientId || e.IngredientFrom.IsNone);

      //   return equivs.SingleOrDefault(e => !e.Ingredient.IsNone)?.Factor
      //      ?? equivs.SingleOrDefault(e => e.Ingredient.IsNone)?.Factor;
      //}
   }
}
