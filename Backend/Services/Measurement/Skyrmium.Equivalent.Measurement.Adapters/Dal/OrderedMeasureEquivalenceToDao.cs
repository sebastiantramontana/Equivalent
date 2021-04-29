using Skyrmium.Adapters.Contracts;
using Skyrmium.Adapters.Implementations.EntitiesToDaos;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   public class OrderedMeasureEquivalenceToDao : EntityToDaoBase<OrderedMeasureEquivalence, OrderedMeasureEquivalenceDao>
   {
      private readonly IAdapter<MeasureEquivalence, MeasureEquivalenceDao> _measureEquivalenceAdapter;

      public OrderedMeasureEquivalenceToDao(IAdapter<MeasureEquivalence, MeasureEquivalenceDao> measureEquivalenceAdapter)
      {
         _measureEquivalenceAdapter = measureEquivalenceAdapter;
      }

      public override OrderedMeasureEquivalence Map(OrderedMeasureEquivalenceDao dao)
      {
         return new OrderedMeasureEquivalence(dao.Id, dao.DistributedId, dao.Order, _measureEquivalenceAdapter.Map(dao.MeasureEquivalence));
      }

      protected override OrderedMeasureEquivalenceDao ContinueEntityToDao(OrderedMeasureEquivalence entity, OrderedMeasureEquivalenceDao dao)
      {
         dao.Order = entity.Order;
         dao.MeasureEquivalence = _measureEquivalenceAdapter.Map(entity.MeasureEquivalence);

         return dao;
      }
   }
}
