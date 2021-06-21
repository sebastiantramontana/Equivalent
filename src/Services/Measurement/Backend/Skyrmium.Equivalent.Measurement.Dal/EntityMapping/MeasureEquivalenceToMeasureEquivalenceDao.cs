using Skyrmium.Dal.Implementations.EntityMapping;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Infrastructure.Contracts;

namespace Skyrmium.Equivalent.Measurement.Dal.EntityMapping
{
   public class MeasureEquivalenceToMeasureEquivalenceDao : OwnedEntityToDaoBase<MeasureEquivalence, MeasureEquivalenceDao>
   {
      private readonly IMapper<Measure, MeasureDao> _measureMapper;

      public MeasureEquivalenceToMeasureEquivalenceDao(IMapper<Measure, MeasureDao> measureMapper)
      {
         _measureMapper = measureMapper;
      }

      protected override MeasureEquivalenceDao ContinueOwnedEntityToDao(MeasureEquivalence entity, MeasureEquivalenceDao dao)
      {
         dao.MeasureFrom = _measureMapper.Map(entity.From.Measure);
         dao.IngredientFrom = entity.From.Ingredient;
         dao.MeasureTo = _measureMapper.Map(entity.To.Measure);
         dao.IngredientTo = entity.To.Ingredient;
         dao.Factor = entity.Factor;

         return dao;
      }

      public override MeasureEquivalence Map(MeasureEquivalenceDao dao)
      {
         return new MeasureEquivalence(
            dao.Id,
            dao.OwnedBy,
            new MeasureIngredient(_measureMapper.Map(dao.MeasureFrom), dao.IngredientFrom),
            new MeasureIngredient(_measureMapper.Map(dao.MeasureTo), dao.IngredientTo),
            dao.Factor);
      }
   }
}
