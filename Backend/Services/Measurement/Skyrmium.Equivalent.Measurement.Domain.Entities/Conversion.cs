﻿using Skyrmium.Domain.Contracts.Exceptions;
using Skyrmium.Domain.Implementations.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skyrmium.Equivalent.Measurement.Domain.Entities
{
   public class Conversion : OwnedEntityBase
   {
      public static Conversion Create(Guid id, Guid ownedBy, string name, IEnumerable<OrderedMeasureEquivalence> equivalences)
      {
         Validate(equivalences, name);

         return new Conversion(id, ownedBy, name, equivalences);
      }

      private Conversion(Guid id, Guid ownedBy, string name, IEnumerable<OrderedMeasureEquivalence> equivalences) : base(id, ownedBy)
      {
         this.Name = name;
         this.Equivalences = equivalences;
      }

      public string Name { get; }
      public IEnumerable<OrderedMeasureEquivalence> Equivalences { get; }

      private static void Validate(IEnumerable<OrderedMeasureEquivalence> equivalences, string conversionName)
      {
         if (!CheckIsNotEmpty(equivalences))
            throw new BusinessException("Conversión Inválida", $"A la conversión {conversionName} le faltan las equivalencias");

         if (!CheckOrderIsUnique(equivalences))
            throw new BusinessException("Conversión Inválida", $"La conversión {conversionName} tiene distintas equivalencias en el mismo orden");

         var orderedEquivalences = equivalences.OrderBy(e => e.Order);

         var prevTo = GetFirstEquivalenceTo(orderedEquivalences);
         var fromSecondOrderedEquivalences = StartFromSecondOrderedEquivalence(orderedEquivalences);

         foreach (var orderedEquivalence in fromSecondOrderedEquivalences)
         {
            if (!CheckPreviousToWithNextFrom(prevTo, orderedEquivalence))
               throw new BusinessException("Conversión Inválida", $"La conversión {conversionName} tiene equivalencias mal ordenadas. El origen de una equivalencia debe ser el mismo del destino de la equivalencia anterior.");

            prevTo = (orderedEquivalence.InvertEquivalence)
               ? orderedEquivalence.MeasureEquivalence.From
               : orderedEquivalence.MeasureEquivalence.To;
         }
      }

      private static IEnumerable<OrderedMeasureEquivalence> StartFromSecondOrderedEquivalence(IEnumerable<OrderedMeasureEquivalence> orderedEquivalences)
      {
         return orderedEquivalences.Skip(1);
      }

      private static MeasureIngredient GetFirstEquivalenceTo(IEnumerable<OrderedMeasureEquivalence> orderedEquivalences)
      {
         return orderedEquivalences
                  .First()
                  .MeasureEquivalence
                  .To;
      }

      private static bool CheckPreviousToWithNextFrom(MeasureIngredient prevTo, OrderedMeasureEquivalence nextOrderedFrom)
      {
         MeasureIngredient nextFrom = (nextOrderedFrom.InvertEquivalence)
            ? nextOrderedFrom.MeasureEquivalence.To
            : nextOrderedFrom.MeasureEquivalence.From;

         return prevTo == nextFrom || (prevTo.Measure == nextFrom.Measure && nextFrom.Ingredient == Guid.Empty);
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
