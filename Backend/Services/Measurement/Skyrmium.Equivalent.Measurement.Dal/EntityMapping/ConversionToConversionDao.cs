using Skyrmium.Dal.Implementations.EntityMapping;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Infrastructure.Contracts;
using System.Linq;

namespace Skyrmium.Equivalent.Measurement.Dal.EntityMapping
{
   public class ConversionToConversionDao : OwnedEntityToDaoBase<Conversion, ConversionDao>
   {
      private readonly IMapper<OrderedMeasureEquivalence, OrderedMeasureEquivalenceDao> _orderedMeasureEquivalenceMapper;

      public ConversionToConversionDao(IMapper<OrderedMeasureEquivalence, OrderedMeasureEquivalenceDao> orderedMeasureEquivalenceMapper)
      {
         _orderedMeasureEquivalenceMapper = orderedMeasureEquivalenceMapper;
      }

      public override Conversion Map(ConversionDao dao)
      {
         var conversion = Conversion.Create(
                           dao.Id,
                           dao.DistributedId,
                           dao.OwnedBy,
                           dao.Name,
                           _orderedMeasureEquivalenceMapper.Map(dao.Equivalences).ToList());

         return conversion;
      }

      protected override ConversionDao ContinueOwnedEntityToDao(Conversion entity, ConversionDao dao)
      {
         dao.Name = entity.Name;
         dao.Equivalences = _orderedMeasureEquivalenceMapper.Map(entity.Equivalences);

         return dao;
      }
   }
}
