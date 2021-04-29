using Skyrmium.Adapters.Contracts;
using Skyrmium.Adapters.Implementations.EntitiesToDtos;
using Skyrmium.Equivalent.Measurement.Api.Dtos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   public class ConversionToConversionDto : OwnedEntityToDtoBase<Conversion, ConversionDto>
   {
      private readonly IAdapter<OrderedMeasureEquivalence, OrderedMeasureEquivalenceDto> _orderedMeasureEquivalenceAdapter;

      public ConversionToConversionDto(IAdapter<OrderedMeasureEquivalence, OrderedMeasureEquivalenceDto> orderedMeasureEquivalenceAdapter)
      {
         _orderedMeasureEquivalenceAdapter = orderedMeasureEquivalenceAdapter;
      }

      public override Conversion Map(ConversionDto dto)
      {
         return Conversion.Create(
            default, 
            dto.DistributedId, 
            dto.OwnedBy, 
            dto.Name, 
            _orderedMeasureEquivalenceAdapter.Map(dto.Equivalences));
      }

      protected override ConversionDto ContinueOwnedEntityToDto(Conversion entity, ConversionDto dto)
      {
         dto.Name = entity.Name;
         dto.Equivalences = _orderedMeasureEquivalenceAdapter.Map(entity.Equivalences);

         return dto;
      }
   }
}
