using Skyrmium.Api.Implementations.EntityMapping;
using Skyrmium.Equivalent.Measurement.Api.Dtos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Infrastructure.Contracts;

namespace Skyrmium.Equivalent.Measurement.Api.EntityMapping
{
   public class ConversionToConversionDto : OwnedEntityToDtoBase<Conversion, ConversionDto>
   {
      private readonly IMapper<OrderedMeasureEquivalence, OrderedMeasureEquivalenceDto> _orderedMeasureEquivalenceMapper;

      public ConversionToConversionDto(IMapper<OrderedMeasureEquivalence, OrderedMeasureEquivalenceDto> orderedMeasureEquivalenceMapper)
      {
         _orderedMeasureEquivalenceMapper = orderedMeasureEquivalenceMapper;
      }

      public override Conversion Map(ConversionDto dto)
      {
         return Conversion.Create(
            dto.Id,
            dto.OwnedBy,
            dto.Name,
            _orderedMeasureEquivalenceMapper.Map(dto.Equivalences));
      }

      protected override ConversionDto ContinueOwnedEntityToDto(Conversion entity, ConversionDto dto)
      {
         dto.Name = entity.Name;
         dto.Equivalences = _orderedMeasureEquivalenceMapper.Map(entity.Equivalences);

         return dto;
      }
   }
}
