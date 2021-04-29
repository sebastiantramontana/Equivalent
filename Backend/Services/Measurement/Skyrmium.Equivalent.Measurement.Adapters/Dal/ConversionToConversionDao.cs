using Skyrmium.Adapters.Contracts;
using Skyrmium.Adapters.Implementations.EntitiesToDaos;
using Skyrmium.Equivalent.Measurement.Dal.Daos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using System.Linq;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   public class ConversionToConversionDao : OwnedEntityToDaoBase<Conversion, ConversionDao>
   {
      private readonly IAdapter<OrderedMeasureEquivalence, OrderedMeasureEquivalenceDao> _orderedMeasureEquivalenceAdapter;

      public ConversionToConversionDao(IAdapter<OrderedMeasureEquivalence, OrderedMeasureEquivalenceDao> orderedMeasureEquivalenceAdapter)
      {
         _orderedMeasureEquivalenceAdapter = orderedMeasureEquivalenceAdapter;
      }

      public override Conversion Map(ConversionDao dao)
      {
         var conversion = Conversion.Create(
                           dao.Id,
                           dao.DistributedId,
                           dao.OwnedBy,
                           dao.Name,
                           _orderedMeasureEquivalenceAdapter.Map(dao.Equivalences).ToList());

         return conversion;
      }

      protected override ConversionDao ContinueOwnedEntityToDao(Conversion entity, ConversionDao dao)
      {
         dao.Name = entity.Name;
         dao.Equivalences = _orderedMeasureEquivalenceAdapter.Map(entity.Equivalences);

         return dao;
      }
   }
}
