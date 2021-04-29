using Skyrmium.Adapters.Contracts;
using Skyrmium.Adapters.Implementations.EntitiesToDtos;
using Skyrmium.Equivalent.Measurement.Api.Dtos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   public class OrderedMeasureEquivalenceToDto : EntityToDtoBase<OrderedMeasureEquivalence, OrderedMeasureEquivalenceDto>
   {
      private readonly IAdapter<MeasureEquivalence, MeasureEquivalenceDto> _measureEquivalenceAdapter;

      public OrderedMeasureEquivalenceToDto(IAdapter<MeasureEquivalence, MeasureEquivalenceDto> measureEquivalenceAdapter)
      {
         _measureEquivalenceAdapter = measureEquivalenceAdapter;
      }

      public override OrderedMeasureEquivalence Map(OrderedMeasureEquivalenceDto dto)
      {
         return new OrderedMeasureEquivalence(
            default,
            dto.DistributedId,
            dto.Order,
            _measureEquivalenceAdapter.Map(dto.MeasureEquivalence));
      }

      protected override OrderedMeasureEquivalenceDto ContinueEntityToDto(OrderedMeasureEquivalence entity, OrderedMeasureEquivalenceDto dto)
      {
         dto.Order = entity.Order;
         dto.MeasureEquivalence = _measureEquivalenceAdapter.Map(entity.MeasureEquivalence);

         return dto;
      }
   }
}
