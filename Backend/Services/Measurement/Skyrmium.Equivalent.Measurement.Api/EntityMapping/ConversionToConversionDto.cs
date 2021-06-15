using Skyrmium.Api.Implementations.EntityMapping;
using Skyrmium.Equivalent.Measurement.Api.Dtos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Equivalent.Measurement.Domain.Entities.Localization.Conversion;
using Skyrmium.Infrastructure.Contracts;

namespace Skyrmium.Equivalent.Measurement.Api.EntityMapping
{
   public class ConversionToConversionDto : OwnedEntityToDtoBase<Conversion, ConversionDto>
   {
      private readonly IMapper<OrderedMeasureEquivalence, OrderedMeasureEquivalenceDto> _orderedMeasureEquivalenceMapper;
      private readonly IConversionLocalizer _converionLocalizer;

      public ConversionToConversionDto(IMapper<OrderedMeasureEquivalence, OrderedMeasureEquivalenceDto> orderedMeasureEquivalenceMapper, IConversionLocalizer converionLocalizer)
      {
         _orderedMeasureEquivalenceMapper = orderedMeasureEquivalenceMapper;
         _converionLocalizer = converionLocalizer;
      }

      public override Conversion Map(ConversionDto dto)
      {
         return Conversion.Create(
            dto.Id,
            dto.OwnedBy,
            dto.Name,
            _orderedMeasureEquivalenceMapper.Map(dto.Equivalences),
            _converionLocalizer);
      }

      protected override ConversionDto ContinueOwnedEntityToDto(Conversion entity, ConversionDto dto)
      {
         dto.Name = entity.Name;
         dto.Equivalences = _orderedMeasureEquivalenceMapper.Map(entity.Equivalences);

         return dto;
      }
   }
}
