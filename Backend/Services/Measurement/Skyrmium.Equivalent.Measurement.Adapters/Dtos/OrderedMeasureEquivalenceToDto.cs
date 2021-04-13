using AutoMapper;
using Skyrmium.Adapters.Implementations.EntitiesToDtos;
using Skyrmium.Equivalent.Measurement.Api.Dtos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   internal class OrderedMeasureEquivalenceToDto : EntityToDtoBase<OrderedMeasureEquivalence, OrderedMeasureEquivalenceDto>
   {
      protected override void ContinueDtoToEntity(IMappingExpression<OrderedMeasureEquivalenceDto, OrderedMeasureEquivalence> mappingExpression)
      {
      }

      protected override void ContinueEntityToDto(IMappingExpression<OrderedMeasureEquivalence, OrderedMeasureEquivalenceDto> mappingExpression)
      {
      }
   }
}
