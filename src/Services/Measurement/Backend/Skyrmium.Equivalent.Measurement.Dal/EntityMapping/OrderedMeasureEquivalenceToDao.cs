using Skyrmium.Dal.Implementations.EntityMapping;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Infrastructure.Contracts;

namespace Skyrmium.Equivalent.Measurement.Dal.EntityMapping
{
   public class OrderedMeasureEquivalenceToDao : EntityToDaoBase<OrderedMeasureEquivalence, OrderedMeasureEquivalenceDao>
   {
      private readonly IMapper<MeasureEquivalence, MeasureEquivalenceDao> _measureEquivalenceMapper;

      public OrderedMeasureEquivalenceToDao(IMapper<MeasureEquivalence, MeasureEquivalenceDao> measureEquivalenceMapper)
      {
         _measureEquivalenceMapper = measureEquivalenceMapper;
      }

      public override OrderedMeasureEquivalence Map(OrderedMeasureEquivalenceDao dao)
      {
         return new OrderedMeasureEquivalence(dao.Id, dao.Order, _measureEquivalenceMapper.Map(dao.MeasureEquivalence), dao.InvertEquivalence);
      }

      protected override OrderedMeasureEquivalenceDao ContinueEntityToDao(OrderedMeasureEquivalence entity, OrderedMeasureEquivalenceDao dao)
      {
         dao.Order = entity.Order;
         dao.MeasureEquivalence = _measureEquivalenceMapper.Map(entity.MeasureEquivalence);
         dao.InvertEquivalence = entity.InvertEquivalence;

         return dao;
      }
   }
}
