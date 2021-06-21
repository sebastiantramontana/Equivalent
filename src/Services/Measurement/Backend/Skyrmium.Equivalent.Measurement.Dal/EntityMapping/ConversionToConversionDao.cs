using Skyrmium.Dal.Implementations.EntityMapping;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Entities.Localization.Conversion;
using Skyrmium.Infrastructure.Contracts;
using System.Linq;

namespace Skyrmium.Equivalent.Measurement.Dal.EntityMapping
{
   public class ConversionToConversionDao : OwnedEntityToDaoBase<Conversion, ConversionDao>
   {
      private readonly IMapper<OrderedMeasureEquivalence, OrderedMeasureEquivalenceDao> _orderedMeasureEquivalenceMapper;
      private readonly IConversionLocalizer _conversionLocalizer;

      public ConversionToConversionDao(IMapper<OrderedMeasureEquivalence, OrderedMeasureEquivalenceDao> orderedMeasureEquivalenceMapper, IConversionLocalizer conversionLocalizer)
      {
         _orderedMeasureEquivalenceMapper = orderedMeasureEquivalenceMapper;
         _conversionLocalizer = conversionLocalizer;
      }

      public override Conversion Map(ConversionDao dao)
      {
         var conversion = Conversion.Create(
                           dao.Id,
                           dao.OwnedBy,
                           dao.Name,
                           _orderedMeasureEquivalenceMapper.Map(dao.Equivalences).ToList(),
                           _conversionLocalizer);

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
