using Skyrmium.Dal.Contracts;
using Skyrmium.Domain.Entities.Contracts;
using Skyrmium.Domain.Entities.Core;
using Skyrmium.Domain.Services.Implementations;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Services.Contracts;
using System.Linq;

namespace Skyrmium.Equivalent.Measurement.Domain.Services.Implementations
{
   public class EquivalentService : CrudServiceBase<MeasureEquivalence>, IEquivalenceService
   {
      public EquivalentService(IRepository<MeasureEquivalence> repository)
         : base(repository)
      {
      }

      public double Convert(Measure from, Measure to)
      {
         var measureEquivalence = this.Repository
             .Get(me =>
                  me.MeasureFrom == from
               && me.MeasureTo == to
               && me.IngredientFrom == DistributableId.None
               && me.IngredientTo == DistributableId.None)
             .SingleOrDefault();

         return measureEquivalence?.Factor ?? throw BusinessExceptionFactory.CreateInexistentEquivalenceException(from, to);
      }

      public double Convert(Measure from, Measure to, IDistributableId ingredient)
      {
         var measureEquivalence = this.Repository
             .Get(me =>
                  me.MeasureFrom == from
               && me.MeasureTo == to
               && me.IngredientFrom == ingredient
               && me.IngredientTo == ingredient)
             .SingleOrDefault();

         return measureEquivalence?.Factor ?? throw BusinessExceptionFactory.CreateInexistentEquivalenceException(from, to, ingredient);
      }

      public double Convert(Measure measureFrom, Measure measureTo, IDistributableId ingredientFrom, IDistributableId ingredientTo)
      {
         var measureEquivalence = this.Repository
             .Get(me =>
                  me.MeasureFrom == measureFrom
               && me.MeasureTo == measureTo
               && me.IngredientFrom == ingredientFrom
               && me.IngredientTo == ingredientTo)
             .SingleOrDefault();

         return measureEquivalence?.Factor ?? throw BusinessExceptionFactory.CreateInexistentEquivalenceException(measureFrom, measureTo, ingredientFrom, ingredientTo);
      }
   }
}
