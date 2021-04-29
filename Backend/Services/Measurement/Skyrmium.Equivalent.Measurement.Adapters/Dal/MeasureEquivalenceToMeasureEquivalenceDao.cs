using Skyrmium.Adapters.Contracts;
using Skyrmium.Adapters.Implementations.EntitiesToDaos;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   public class MeasureEquivalenceToMeasureEquivalenceDao : OwnedEntityToDaoBase<MeasureEquivalence, MeasureEquivalenceDao>
   {
      private readonly IAdapter<Measure, MeasureDao> _measureAdapter;

      public MeasureEquivalenceToMeasureEquivalenceDao(IAdapter<Measure, MeasureDao> measureAdapter)
      {
         _measureAdapter = measureAdapter;
      }

      protected override MeasureEquivalenceDao ContinueOwnedEntityToDao(MeasureEquivalence entity, MeasureEquivalenceDao dao)
      {
         dao.MeasureFrom = _measureAdapter.Map(entity.From.Measure);
         dao.IngredientFrom = entity.From.Ingredient;
         dao.MeasureTo = _measureAdapter.Map(entity.To.Measure);
         dao.IngredientTo = entity.To.Ingredient;
         dao.Factor = entity.Factor;

         return dao;
      }

      public override MeasureEquivalence Map(MeasureEquivalenceDao dao)
      {
         return new MeasureEquivalence(
            dao.Id,
            dao.DistributedId,
            dao.OwnedBy,
            new MeasureIngredient(_measureAdapter.Map(dao.MeasureFrom), dao.IngredientFrom),
            new MeasureIngredient(_measureAdapter.Map(dao.MeasureTo), dao.IngredientTo),
            dao.Factor);
      }
   }
}
