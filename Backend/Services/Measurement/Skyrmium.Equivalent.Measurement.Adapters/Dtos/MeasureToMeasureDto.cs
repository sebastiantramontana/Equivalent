using AutoMapper;
using Skyrmium.Adapters.Implementations.EntitiesToDtos;
using Skyrmium.Equivalent.Measurement.Api.Dtos;
using Skyrmium.Equivalent.Measurement.Domain.Entities;

namespace Skyrmium.Equivalent.Measurement.Adapters.Dal
{
   internal class MeasureToMeasureDto : OwnedEntityToOwnedDtoBase<Measure, MeasureDto>
   {
      protected override void ContinueWithOwnedEntity(IMappingExpression<Measure, MeasureDto> mappingExpression)
      {
         mappingExpression
            .ForMember(d => d.FullName, c => c.MapFrom(e => e.FullName))
            .ForMember(d => d.ShortName, c => c.MapFrom(e => e.ShortName));
      }

      protected override void ContinueWithOwnedDto(IMappingExpression<MeasureDto, Measure> mappingExpression)
      {
         mappingExpression
            .ForMember(e => e.FullName, c => c.MapFrom(d => d.FullName))
            .ForMember(e => e.ShortName, c => c.MapFrom(d => d.ShortName));
      }
   }
}
