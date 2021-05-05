using Skyrmium.Api.Implementations.EntityMapping;
using Skyrmium.Equivalent.Measurement.Api.Dtos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;
using Skyrmium.Infrastructure.Contracts;

namespace Skyrmium.Equivalent.Measurement.Api.EntityMapping
{
   public class OrderedMeasureEquivalenceToDto : EntityToDtoBase<OrderedMeasureEquivalence, OrderedMeasureEquivalenceDto>
   {
      private readonly IMapper<MeasureEquivalence, MeasureEquivalenceDto> _measureEquivalenceMapper;

      public OrderedMeasureEquivalenceToDto(IMapper<MeasureEquivalence, MeasureEquivalenceDto> measureEquivalenceMapper)
      {
         _measureEquivalenceMapper = measureEquivalenceMapper;
      }

      public override OrderedMeasureEquivalence Map(OrderedMeasureEquivalenceDto dto)
      {
         return new OrderedMeasureEquivalence(
            default,
            dto.DistributedId,
            dto.Order,
            _measureEquivalenceMapper.Map(dto.MeasureEquivalence));
      }

      protected override OrderedMeasureEquivalenceDto ContinueEntityToDto(OrderedMeasureEquivalence entity, OrderedMeasureEquivalenceDto dto)
      {
         dto.Order = entity.Order;
         dto.MeasureEquivalence = _measureEquivalenceMapper.Map(entity.MeasureEquivalence);

         return dto;
      }
   }
}
