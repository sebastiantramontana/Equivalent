using AutoMapper;
using Skyrmium.Adapters.Implementations.EntitiesToDtos;
using Skyrmium.Equivalent.Measurement.Api.Dtos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   internal class MeasureToMeasureDto : OwnedEntityToDtoBase<Measure, MeasureDto>
   {
      protected override void ContinueWithEntity(IMappingExpression<Measure, MeasureDto> mappingExpression)
      {
      }

      protected override void ContinueWithDto(IMappingExpression<MeasureDto, Measure> mappingExpression)
      {
      }
   }
}
