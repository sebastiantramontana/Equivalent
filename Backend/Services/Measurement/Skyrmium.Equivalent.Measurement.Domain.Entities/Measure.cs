using Skyrmium.Domain.Entities.Contracts;
using Skyrmium.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities
{
   public class Measure : OwnedDistributableEntityBase
   {
      public Measure(long id, IDistributableId distributedId, IDistributableId ownedBy) : base(id, distributedId, ownedBy)
      {
      }

      public string FullName { get; set; }

      public string ShortName { get; set; }

      public ICollection<MeasureEquivalence> Equivalences { get; set; }

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
